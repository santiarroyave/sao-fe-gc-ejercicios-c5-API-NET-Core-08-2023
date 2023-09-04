# T31 - Ejercicio 2
## Paquetes utilizados
- [Microsoft.EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/)
- [Microsoft.EntityFrameworkCore.InMemory](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.InMemory/)
- [Microsoft.EntityFrameworkCore.SqlServer](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/)

## Recursos
```sql
CREATE TABLE cliente(
    id int(11) NOT NULL auto_increment,
    nombre varchar(250) DEFAULT NULL,
    apellido varchar(250) DEFAULT NULL,
    direccion varchar(250) DEFAULT NULL,
    dni int(11) DEFAULT NULL,
    fecha date DEFAULT NULL,
    PRIMARY KEY(id)
);

CREATE TABLE videos(
    id int(11) NOT NULL auto_increment,
    title varchar(250) DEFAULT NULL,
    director varchar(250) DEFAULT NULL,
    cli_id int(11) DEFAULT NULL,
    PRIMARY KEY(id),
    CONSTRAINT videos_fk FOREIGN KEY(cli_id) REFERENCES cliente(id)
);
```

## Notas
### Context
Opciones a la hora de mapear:

*Estas configuraciones van en el context, dentro del método OnModelCreating*

Primera opción, permite editar las propiedades y otros campos de manera más detallada:
```csharp
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

    // Foreign key
    videos.HasOne(p => p.cliente).WithMany(p => p.videos).HasForeignKey(p => p.cli_id);
});
```

Segunda opción y más sencilla:
```csharp
modelBuilder.Entity<Videos>()
    .HasOne(p => p.cliente)
    .WithMany(p => p.videos)
    .HasForeignKey(p => p.cli_id)
    .OnDelete(DeleteBehavior.Cascade);
```