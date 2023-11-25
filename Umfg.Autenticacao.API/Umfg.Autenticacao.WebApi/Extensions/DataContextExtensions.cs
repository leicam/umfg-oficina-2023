using Microsoft.EntityFrameworkCore;
using Ufmg.Autenticacao.Dominio.Classes;
using Umfg.Autenticacao.Repositorio.Context;

namespace Umfg.Autenticacao.WebApi.Extensions
{
    internal static class DataContextExtensions
    {
        internal static void AddDataContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            var configurationConnectionString = configuration
                .GetSection(nameof(ConnectionString)).GetChildren();
            var autenticacao = configurationConnectionString
                .FirstOrDefault(x => x.Key == nameof(ConnectionString.Autenticacao))?.Value ?? string.Empty;

            services.AddDbContext<DataContext>(options => options.UseMySQL(autenticacao));
        }
    }
}