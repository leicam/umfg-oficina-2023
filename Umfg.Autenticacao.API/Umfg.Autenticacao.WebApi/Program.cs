
using Umfg.Autenticacao.WebApi.Extensions;

namespace Umfg.Autenticacao.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddServiceCors();
            builder.Services.AddAutenticacao(builder.Configuration);
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddRouting(options => options.LowercaseUrls = true);
            builder.Services.AddSwagger();
            builder.Services.AddServices();

            var app = builder.Build();

            app.UseCors();
            app.UseSwaggerApp();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}