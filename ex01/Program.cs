using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ex01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ClienteContext>(p => p.UseInMemoryDatabase("ClientesDB"));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            // Paso 6: Hacer mapeo para verificar que EF es capaz de generar la DB y que es en memoria.
            app.MapGet("/dbconexion", async ([FromServices] ClienteContext dbContext) =>
            {
                dbContext.Database.EnsureCreated();
                return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
            });

            app.Run();
        }
    }
}