using Microsoft.EntityFrameworkCore;
using PruebaAHVA.Models;

namespace PruebaAHVA.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Rol>().HasData(
                new Rol { Id = 1, Nombre = "Operador" },
                new Rol { Id = 2, Nombre = "Administrador" }
            );

            // Seed user data
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    Email = "jesusmarichal0@gmail.com",
                    Password = "28344112",
                    Nombre = "Jesus",
                    NumeroDocumento = "28344112",
                    Estado = "Activo",
                    IntentosFallidos = 0,
                    RolId = 1
                }
            );
        }
    }
}
