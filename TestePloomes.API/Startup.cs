using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TestePloomes.Data.Interfaces;
using TestePloomes.Data.Repositories;
using TestePloomes.Domain.Interfaces;
using TestePloomes.Domain.Services;
using TestePloomes.Data;

namespace TestePloomes.API {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {

            services.AddDbContext<TestePloomesContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddControllers();
            services.AddSwaggerGen(c => {
                c.EnableAnnotations();
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TestePloomes.API Documentação", Version = "v1" });
            });

            services.AddScoped<IClientesRepository, ClientesRepository>();
            services.AddScoped<IClientesService, ClientesService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {

            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TestePloomes.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
