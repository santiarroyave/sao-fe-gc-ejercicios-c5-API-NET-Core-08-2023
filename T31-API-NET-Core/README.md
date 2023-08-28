# T31 API .NET Core

## Notas
- Me ha dado error al crear los controladores (paso 5).
- El paso 6 ya se estaba aplicando por defecto en el archivo **Program.cs**.

## Pasos
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
4. Añadir registro del contexto de base de datos (Startup.cs)
```csharp
using Microsoft.EntityFrameworkCore;
using T31_API_NET_Core.Models;

namespace T31_API_NET_Core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<APIContext>(opt =>
                opt.UseInMemoryDatabase("APIList"));
            services.AddControllers();

            // Paso 6
            services.AddSwaggerGen();
        }
    }
}
```
5. Scaffolding de un controlador<br>
    `Models > Agregar > Nuevo elemento con scaffold... > Controlador de API con acciones que usan Entity Framework`

6. Agregar y configurar el middleware de Swagger: `Startup.Configure`
```csharp
//...
public void Configure(IApplicationBuilder app)
{
    app.UseSwagger();

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });

    app.UseRouting();
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
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