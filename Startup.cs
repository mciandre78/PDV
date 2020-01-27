using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using pdv.Data;
using pdv.Contracts;
using pdv.Interfaces;
using pdv.Repos;
using pdv.Services;

namespace PDV
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
            services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("DataBase"));
            services.AddScoped<DataContext, DataContext>();
            services.AddScoped(serviceType: typeof(IUnitOfWork), implementationType: typeof(UnitOfWork));
            services.AddScoped(serviceType: typeof(IRepository<>), implementationType: typeof(GenericRepository<>));

            services.AddSwaggerGen(s => s.SwaggerDoc("v1", new OpenApiInfo { Title = "Desafio PDV", Version = "v1" }));
            services.AddControllers();
        }
                
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }            

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger();

            app.UseAuthorization();

            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}