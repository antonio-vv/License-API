using License_API.Repos;
using Microsoft.OpenApi.Models;
using MySql.Data.MySqlClient;
using License_API.Settings;
using License_API.Interfaces;

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
                MySqlConnection sqlconn = new(settings.Connection);
                sqlconn.Open();
                return sqlconn;
            });
            services.AddSingleton<InterfLicenses, LicensesInMySql>();
            services.AddSingleton<InterfOrganizations, OrganizationsInMySql>();
            services.AddSingleton<InterfServers, ServersInMySql>();
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
