using Microsoft.OpenApi.Models;

namespace Umfg.Autenticacao.WebApi.Extensions
{
    internal static class SwaggerExtensions
    {
        private const string C_XML_FILENAME = "Umfg.Autenticacao.SwaggerAnnotation.xml";

        internal static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", 
                    new OpenApiInfo 
                    { 
                        Title = "UMFG Educacional Autenticação API V1",
                        Version = "v1",
                    });
                options.ResolveConflictingActions(x => x.FirstOrDefault());
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, C_XML_FILENAME));
            });
        }

        internal static void UseSwaggerApp(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint($"/swagger/v1/swagger.json", "UMFG Educacional Autenticação API V1");
            });
        }
    }
}