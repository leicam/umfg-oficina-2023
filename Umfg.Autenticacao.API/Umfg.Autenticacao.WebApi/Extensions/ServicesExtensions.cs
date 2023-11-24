using Microsoft.AspNetCore.Identity;

namespace Umfg.Autenticacao.WebApi.Extensions
{
    internal static class ServicesExtensions
    {
        internal static void AddServices(this IServiceCollection services)
        {
            services
                .AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddDefaultTokenProviders();
        }
    }
}