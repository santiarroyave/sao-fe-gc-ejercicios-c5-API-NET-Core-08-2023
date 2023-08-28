# T31 API .NET Core 
1. Crear proyecto **ASP.NET Core Web API**
2. Instalar paquetes
    - [Microsoft.EntityFrameworkCore.SqlServer](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/7.0.10)
    - [Microsoft.EntityFrameworkCore.InMemory](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.InMemory/7.0.10)
3. Añadir contexto de la base de datos
    ```csharp
    using Microsoft.EntityFrameworkCore;

    namespace T31_API_NET_Core.Models
    {
        public class APIContext : DbContext
        {
            public APIContext(DbContextOptions<APIContext> options) :base(options) { }

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
    ```

## Models usados para el ejemplo
```csharp
namespace T31_API_NET_Core.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool IsComplete { get; set;}
        public Empresa Empresa { get; set; }
    }
}
```

```csharp
namespace T31_API_NET_Core.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nom_emp { get; set; }
        public bool IsComplete { get; set; }
        public ICollection<Empleado> Empleados { get; set; }
    }
}

```