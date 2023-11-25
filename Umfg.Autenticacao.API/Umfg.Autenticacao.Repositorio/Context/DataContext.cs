using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System.Data.Entity;
using Umfg.Autenticacao.Repositorio.Extensions;

namespace Umfg.Autenticacao.Repositorio.Context
{
    [DbConfigurationType(typeof(MySqlConfiguration))]
    public sealed class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            ApplyMigrations();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureIdentity();
        }

        private void ApplyMigrations()
        {
            var teste = Database.CanConnect();
            if (Database.GetPendingMigrations().Any())
                Database.Migrate();
        }
    }
}