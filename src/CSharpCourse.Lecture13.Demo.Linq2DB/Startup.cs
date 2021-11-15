using CSharpCourse.Lecture13.Demo.FluentMigrator;
using CSharpCourse.Lecture13.Demo.Linq2DB.Configurations;
using CSharpCourse.Lecture13.Demo.Linq2DB.DbContexts;
using LinqToDB.AspNet;
using LinqToDB.AspNet.Logging;
using LinqToDB.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CSharpCourse.Lecture13.Demo.Linq2DB
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLinqToDbContext<MessengerDbContext>((provider, options) =>
            {
                var dbConfiguration = Configuration.GetSection(nameof(DbConfiguration)).Get<DbConfiguration>();
                options.UsePostgreSQL(dbConfiguration.ConnectionString)
                    //default logging will log everything using the ILoggerFactory configured in the provider
                    .UseDefaultLogging(provider);
            });

            services.AddMigrations(typeof(InitialMigration).Assembly, Configuration);
            
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
