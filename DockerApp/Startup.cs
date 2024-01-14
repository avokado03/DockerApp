using DockerApp.DB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace DockerApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddDbContext<WeatherContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString(nameof(WeatherContext))));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DockerApp", Version = "v1" });
                c.AddServer(new OpenApiServer() { Url = "http://localhost:5050", Description = "Default" });
                //c.AddServer(new OpenApiServer() { 
                //    Url = Environment.GetEnvironmentVariable("EXTERNAL_API_URL") ?? "https://localhost:8089",
                //    Description = "External"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DockerApp v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors(options => 
                options.AllowAnyMethod().
                        AllowAnyHeader().
                        SetIsOriginAllowed(origin => true).
                        AllowCredentials());
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
