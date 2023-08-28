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

            // Registra el generador Swagger, definiendo 1 o más documentos Swagger
            services.AddSwaggerGen();
        }

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
    }
}
