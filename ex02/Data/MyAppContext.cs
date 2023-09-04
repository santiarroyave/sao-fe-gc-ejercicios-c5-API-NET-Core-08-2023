using ex02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ex02.Data
{
    public class MyAppContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Videos> Videos { get; set; }

        public MyAppContext(DbContextOptions<MyAppContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Otra opción:
            //modelBuilder.Entity<Videos>()
            //    .HasOne(p => p.cliente)
            //    .WithMany(p => p.videos)
            //    .HasForeignKey(p => p.cli_id)
            //    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cliente>(cliente =>
            {
                cliente.ToTable("Cliente");
                cliente.HasKey(p => p.id);
                cliente.Property(p => p.nombre).HasMaxLength(250);
                cliente.Property(p => p.apellido).HasMaxLength(250);
                cliente.Property(p => p.direccion).HasMaxLength(250);
                cliente.Property(p => p.dni).HasMaxLength(11);
            });

            modelBuilder.Entity<Videos>(videos =>
            {
                videos.ToTable("Videos");
                videos.HasKey(p => p.id);
                videos.Property(p => p.title).HasMaxLength(250);
                videos.Property(p => p.director).HasMaxLength(250);
                videos.Property(p => p.cli_id).HasMaxLength(11);

                //Foreign key
                videos.HasOne(p => p.cliente).WithMany(p => p.videos).HasForeignKey(p => p.cli_id).OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
