using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Modelos;
using System.Reflection;

namespace CueritosChapaChapa.AccesoDatos.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Cueritos> Cueritos { get; set; }
        public DbSet<Churros> Churros { get; set; }
        public DbSet<Papas> Papas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
