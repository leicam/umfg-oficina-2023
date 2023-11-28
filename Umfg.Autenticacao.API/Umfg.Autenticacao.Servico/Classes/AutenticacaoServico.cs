using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Ufmg.Autenticacao.Dominio.Classes;
using Ufmg.Autenticacao.Dominio.Constantes;
using Ufmg.Autenticacao.Dominio.Interfaces.Servicos;
using Umfg.Autenticacao.DTO.Classes;

namespace Umfg.Autenticacao.Servico.Classes
{
    public sealed class AutenticacaoServico : IAutenticacaoServico
    {
        #region variaveis privadas

        private readonly string[] _roles = new string[] { Role.Desenvolvedor, Role.Admin, Role.Padrao };
        private readonly JwtSecurityTokenHandler _handler = new JwtSecurityTokenHandler();

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JwtOptions _jwtOptions;

        #endregion variaveis privadas

        #region metodos construtores

        public AutenticacaoServico(SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userInManager,
            RoleManager<IdentityRole> roleInManager,
            IOptions<JwtOptions> jwtOptions)
        {
            _signInManager = signInManager;
            _userManager = userInManager;
            _roleManager = roleInManager;
            _jwtOptions = jwtOptions.Value;
        }

        #endregion  metodos construtores

        #region metodos publicos

        public async Task CadastrarAsync(UsuarioDTO.SingUp dto)
        {
            var identityUser = new IdentityUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                EmailConfirmed = true,
            };

            var result = await _userManager.CreateAsync(identityUser, dto.Password);

            if (!result.Succeeded && result.Errors.Any())
                throw new ApplicationException(result.Errors.Select(x => x.Description).ToString());

            await AddDefaultRolesAsync();
            await AddDefaultRoleToUserAsync(identityUser, Role.Padrao);

            await _userManager.SetLockoutEnabledAsync(identityUser, true);
        }

        public async Task<UsuarioDTO.SingInResponse> LoginAsync(UsuarioDTO.SingIn dto)
        {
            var result = await _signInManager.PasswordSignInAsync(dto.Email, dto.Password, false, true);

            if (!result.Succeeded)
                throw new ApplicationException(ObterMensagemErroLogin(result));

            return await GerarCredenciaisAsync(dto.Email);
        }

        #endregion metodos publicos

        #region metodos privados

        private async Task AddDefaultRoleToUserAsync(IdentityUser identityUser, string role)
        {
            if (await _roleManager.FindByNameAsync(role) == null)
                throw new ApplicationException("Configuração inicial não cadastrada! \n Entre em contato com o suporte.");

            await _userManager.AddToRoleAsync(identityUser, role);
        }

        private async Task AddDefaultRolesAsync()
        {
            foreach (var role in _roles)
                if (!await _roleManager.RoleExistsAsync(role))
                    await _roleManager.CreateAsync(new IdentityRole(role));
        }

        private async Task<UsuarioDTO.SingInResponse> GerarCredenciaisAsync(string email)
        {
            var identityUser = await _userManager.FindByNameAsync(email)
                ?? throw new ApplicationException("Usuário não cadastrado! Verifique.");

            return new UsuarioDTO.SingInResponse
            {
                AcessToken = await GerarAccessTokenAsync(identityUser),
                RefreshToken = GenerateRefreshToken(identityUser),
            };
        }

        private string GenerateRefreshToken(IdentityUser identityUser)
        {
            var jwt = new JwtSecurityToken
                (
                    issuer: _jwtOptions.Issuer,
                    audience: _jwtOptions.Audiance,
                    claims:ObterRefreshTokenClaims(identityUser),
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.AddHours(_jwtOptions.AccessTokenExpiration),
                    signingCredentials: _jwtOptions.SigningCredentials
                );

            return _handler.WriteToken(jwt);
        }

        private IEnumerable<Claim> ObterRefreshTokenClaims(IdentityUser identityUser)
        {
            return new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, identityUser.Id),
                new Claim(JwtRegisteredClaimNames.Email, identityUser?.Email ?? string.Empty),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
            };
        }

        private async Task<string> GerarAccessTokenAsync(IdentityUser identityUser)
        {
            var jwt = new JwtSecurityToken
                (
                    issuer: _jwtOptions.Issuer,
                    audience: _jwtOptions.Audiance,
                    claims: await ObterAccessTokenClaimsAsync(identityUser),
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.AddHours(_jwtOptions.AccessTokenExpiration),
                    signingCredentials: _jwtOptions.SigningCredentials
                );

            return _handler.WriteToken(jwt);
        }

        private async Task<IEnumerable<Claim>> ObterAccessTokenClaimsAsync(IdentityUser identityUser)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, identityUser.Id),
                new Claim(JwtRegisteredClaimNames.Email, identityUser?.Email ?? string.Empty),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
            };

            var userClaims = await _userManager.GetClaimsAsync(identityUser);
            var userRoles = await _userManager.GetRolesAsync(identityUser);

            claims.AddRange(userClaims);

            foreach (var role in userRoles)
                claims.Add(new Claim(ClaimTypes.Role, role));

            return claims;
        }

        private string ObterMensagemErroLogin(SignInResult result)
        {
            if (result.IsLockedOut)
                return "Conta bloqueada! Verifique.";
            else if (result.IsNotAllowed)
                return "Conta sem permissão para login! Verifique.";
            else if (result.RequiresTwoFactor)
                return "Confirme seu login com seu segundo fator de autenticação!";

            return "Usuário ou senha incorretos! Verifique.";
        }

        #endregion metodos privados
    }
}