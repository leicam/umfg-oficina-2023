using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufmg.Autenticacao.Dominio.Classes;
using Ufmg.Autenticacao.Dominio.Interfaces.Servicos;

namespace Umfg.Autenticacao.Servico.Classes
{
    public sealed class AutenticacaoServico : IAutenticacaoServico
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JwtOptions _jwtOptions;

        public AutenticacaoServico(SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userInManager,
            RoleManager<IdentityRole> roleInManager,
            IOptions<JwtOptions> jwtOptions)
        {
            _signInManager = signInManager;
            _userManager = userInManager;
            _roleManager = roleInManager;
            _jwtOptions = jwtOptions.Value;

            CreateRoles();
        }

        private async Task CreateRoles()
        {
            if (!await _roleManager.RoleExistsAsync("TESTE"))
                _roleManager.CreateAsync(new IdentityRole("TESTE"));
        }
    }
}