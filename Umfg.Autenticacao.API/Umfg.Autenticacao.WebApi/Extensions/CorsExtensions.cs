namespace Umfg.Autenticacao.WebApi.Extensions
{
    internal static class CorsExtensions
    {
        internal static void AddServiceCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
        }
    }
}