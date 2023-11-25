using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Umfg.Autenticacao.Repositorio.Extensions
{
    internal static class IdentityExtensions
    {
        internal static void ConfigureIdentity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUser>(entity =>
            {
                entity.Property(p => p.Id).HasMaxLength(110);
                entity.Property(p => p.Email).HasMaxLength(127);
                entity.Property(p => p.NormalizedEmail).HasMaxLength(127);
                entity.Property(p => p.UserName).HasMaxLength(127);
                entity.Property(p => p.NormalizedUserName).HasMaxLength(127);
            });

            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.Property(p => p.Id).HasMaxLength(200);
                entity.Property(p => p.Name).HasMaxLength(127);
                entity.Property(p => p.NormalizedName).HasMaxLength(127);
            });

            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.Property(p => p.LoginProvider).HasMaxLength(127);
                entity.Property(p => p.ProviderKey).HasMaxLength(127);
            });

            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.Property(p => p.UserId).HasMaxLength(127);
                entity.Property(p => p.RoleId).HasMaxLength(127);
            });

            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.Property(p => p.UserId).HasMaxLength(110);
                entity.Property(p => p.LoginProvider).HasMaxLength(110);
                entity.Property(p => p.Name).HasMaxLength(110);
            });
        }
    }
}