using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Revifast.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=.\\SQLExpress;Database=DbRevifastFASGugz;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUser>().ToTable("Usuario").Property(p => p.Id).HasColumnName("UsuarioId");
            
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("RolUsuario");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("LoginUsuario");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("ClaimUsuario");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("TokenUsuario");

            modelBuilder.Entity<IdentityRole>().ToTable("Rol");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RolClaim");
        }
    }
}
