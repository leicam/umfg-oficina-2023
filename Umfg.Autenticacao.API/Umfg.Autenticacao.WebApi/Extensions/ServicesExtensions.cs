using Microsoft.AspNetCore.Identity;
using Ufmg.Autenticacao.Dominio.Interfaces.Servicos;
using Umfg.Autenticacao.Repositorio.Context;
using Umfg.Autenticacao.Servico.Classes;

namespace Umfg.Autenticacao.WebApi.Extensions
{
    internal static class ServicesExtensions
    {
        internal static void AddServices(this IServiceCollection services)
        {
            services
                .AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IAutenticacaoServico, AutenticacaoServico>();
        }
    }
}