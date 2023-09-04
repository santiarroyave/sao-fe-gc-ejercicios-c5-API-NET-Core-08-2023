# C5-T31 API .NET Core
## Links
- [Ejercicio 1](https://github.com/santiarroyave/sao-fe-gc-ejercicios-c5-T31-API-NET-Core-08-2023/tree/main/ex01)
- [Ejercicio 2](https://github.com/santiarroyave/sao-fe-gc-ejercicios-c5-T31-API-NET-Core-08-2023/tree/main/ex02)
- [Ejercicio 3](https://github.com/santiarroyave/sao-fe-gc-ejercicios-c5-T31-API-NET-Core-08-2023/tree/main/ex03)

- [Pasos (ex01)](https://github.com/santiarroyave/sao-fe-gc-ejercicios-c5-T31-API-NET-Core-08-2023/blob/main/ex01/README.md#pasos)
- [Notas (ex02)](https://github.com/santiarroyave/sao-fe-gc-ejercicios-c5-T31-API-NET-Core-08-2023/blob/main/ex02/README.md#notas)

## Configuraciones
### Conectar a BBDD InMemory
Configurar **EF.InMemory** en *Program.cs*. *(Debe estar puesto antes de que se construya la aplicación: "var app = builder.Build();")*
```csharp
builder.Services.AddDbContext<ClienteContext>(p => p.UseInMemoryDatabase("ClientesDB"));
```

Para verificar la conexión se puede hacer un mapeo en *Program.cs*
```csharp
app.MapGet("/dbconexion", async ([FromServices] ClienteContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
});
// Resultado esperado: "Base de datos en memoria: True"
```
Nota: Se puede verificar desde Swagger o con Postman desde *(https://localhost:7078/dbconexion)*.


### OnModelCreating
**OnModelCreating()** se utiliza para configurar cómo las clases del modelo se deben mapear a las tablas existentes en la base de datos o para especificar cómo se deben crear las tablas si aún no existen.

Este metodo sustituye el uso de atributos en los modelos. 
