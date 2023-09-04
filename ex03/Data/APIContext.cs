using ex03.Models;
using Microsoft.EntityFrameworkCore;

namespace ex03.Data
{
    public class APIContext : DbContext
    {
        // Atributos
        public DbSet<Proyecto> proyecto { get; set;}
        public DbSet<Cientifico> cientifico { get; set;}
        public DbSet<Cientifico_Proyecto> cientifico_Proyectos { get; set;}

        // Constructor
        public APIContext(DbContextOptions<APIContext> options) : base(options) { }

        // Metodos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Tabla intermedia (Cientifico_Proyecto)
            modelBuilder.Entity<Cientifico_Proyecto>()
                .HasKey(cp => new { cp.cientifico_dni, cp.proyecto_id });

            modelBuilder.Entity<Cientifico_Proyecto>()
                .HasOne(p => p.Cientifico)
                .WithMany(p => p.cientifico_proyecto)
                .HasForeignKey(pc => pc.cientifico_dni);

            modelBuilder.Entity<Cientifico_Proyecto>()
                .HasOne(p => p.Proyecto)
                .WithMany(p => p.cientifico_proyecto)
                .HasForeignKey(p =>  p.proyecto_id);

            // TablaA (Cientifico)
            modelBuilder.Entity<Cientifico>(cientifico =>
            {
                cientifico.ToTable("Cliente");
                cientifico.HasKey(p => p.dni);
                cientifico.Property(p => p.dni).HasMaxLength(8);
                cientifico.Property(p => p.nomApels).HasMaxLength(255);
            });

            // TablaB (Proyecto)
            modelBuilder.Entity<Proyecto>(proyecto =>
            {
                proyecto.ToTable("Proyecto");
                proyecto.HasKey(p => p.id);
                proyecto.Property(p => p.id).HasMaxLength(4);
                proyecto.Property(p => p.nombre).HasMaxLength(255);
            });
        }
    }
}
