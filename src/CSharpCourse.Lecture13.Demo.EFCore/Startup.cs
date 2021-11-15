using CSharpCourse.Lecture13.Demo.EFCore.Configurations;
using CSharpCourse.Lecture13.Demo.EFCore.DbContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CSharpCourse.Lecture13.Demo.EFCore
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public IWebHostEnvironment WebHostEnvironment { get; set; }

        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            WebHostEnvironment = webHostEnvironment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MessengerDbContext>(opt =>
            {
                var dbConfiguration = Configuration.GetSection(nameof(DbConfiguration)).Get<DbConfiguration>();
                opt.UseNpgsql(dbConfiguration.ConnectionString, action =>
                {
                    action.MigrationsAssembly(typeof(EFCoreMigrator.Constants).Assembly.FullName);
                });
            });

            services.AddLogging(opt =>
            {
                opt.AddConsole();
                opt.SetMinimumLevel(LogLevel.Trace);
            });

            services.AddSwaggerGen(opt =>
            {
                
            });
            
            services.AddControllers();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
