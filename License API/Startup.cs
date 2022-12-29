using License_API.Repos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;
using MySql.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using License_API.Settings;

namespace License_API
{
    public class Startup
    {
        public Startup(IConfiguration config) 
        {
            Configuration = config;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<MySqlConnection>(ServiceProvider =>
            {
                var settings = Configuration.GetSection(nameof(MySQLSettings)).Get<MySQLSettings>();
                return new MySqlConnection(settings.Connection);
            });
            services.AddSingleton<IKeysInMem, KeysInMySql>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "License API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SUI"));

                app.UseHttpsRedirection();
                app.UseRouting();
                app.UseAuthorization();
                
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            }
        }
    }
}
