using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Ufmg.Autenticacao.Dominio.Classes;

namespace Umfg.Autenticacao.WebApi.Extensions
{
    internal static class AutenticacaoExtension
    {
        internal static void AddAutenticacao(this IServiceCollection services, 
            IConfiguration configuration)
        {
            var configurationSectionJwtOptions = configuration
                .GetSection(nameof(JwtOptions))
                .GetChildren();
            var securityKey = configurationSectionJwtOptions
                .FirstOrDefault(x => x.Key == nameof(JwtOptions.SecurityKey))?.Value ?? string.Empty;
            var issuer = configurationSectionJwtOptions
                .FirstOrDefault(x => x.Key == nameof(JwtOptions.Issuer))?.Value ?? string.Empty;
            var audience = configurationSectionJwtOptions
                .FirstOrDefault(x => x.Key == nameof(JwtOptions.Audiance))?.Value ?? string.Empty;
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(securityKey));

            var tokenValidationParameter = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = issuer,

                ValidateAudience = true,
                ValidAudience = audience,
                
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = symmetricSecurityKey,

                RequireExpirationTime = true,
                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero,
            };

            services.Configure<JwtOptions>(options =>
            {
                options.Issuer = issuer;
                options.Audiance = audience;
                options.AccessTokenExpiration = int.Parse(configurationSectionJwtOptions
                    .FirstOrDefault(x => 
                                      x.Key == nameof(JwtOptions.AccessTokenExpiration))?.Value ?? "0");
                options.RefreshTokenExpiration = int.Parse(configurationSectionJwtOptions
                    .FirstOrDefault(x => 
                                      x.Key == nameof(JwtOptions.RefreshTokenExpiration))?.Value ?? "0");
                options.SigningCredentials = new SigningCredentials(symmetricSecurityKey,
                    SecurityAlgorithms.HmacSha256Signature);
            });

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 8;
            });

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = true;
                    options.SaveToken = true;
                    options.TokenValidationParameters = tokenValidationParameter;
                });
        }
    }
}