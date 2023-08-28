using Microsoft.EntityFrameworkCore;

namespace T31_API_NET_Core.Models
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options) : base(options) { }

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Empresa> Empresas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empresa>()
                .HasMany(p => p.Empleados)
                .WithOne(b => b.Empresa);
        }
    }
}
