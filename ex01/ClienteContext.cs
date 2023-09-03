using ex01.Models;
using Microsoft.EntityFrameworkCore;

namespace ex01
{
    public class ClienteContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public ClienteContext(DbContextOptions<ClienteContext> options) :base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(cliente =>
            {
                cliente.ToTable("Cliente");
                cliente.HasKey(p => p.clienteId);
                cliente.Property(p => p.nombre).HasMaxLength(250);
                cliente.Property(p => p.apellido).HasMaxLength(250);
                cliente.Property(p => p.direccion).HasMaxLength(250);
                cliente.Property(p => p.dni).HasMaxLength(11);
            });
        }
    }
}
