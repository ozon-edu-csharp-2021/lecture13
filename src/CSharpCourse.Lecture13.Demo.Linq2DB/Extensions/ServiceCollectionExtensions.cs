using System.Reflection;
using CSharpCourse.Lecture13.Demo.Linq2DB.Configurations;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        ///<summary>
        /// Migrations setup
        ///</summary>
        public static IServiceCollection AddMigrations(this IServiceCollection services, Assembly assembly,
            IConfiguration configuration)
        {
            var dbConfiguration = configuration.GetSection(nameof(DbConfiguration)).Get<DbConfiguration>();
            
            services
                .AddFluentMigratorCore()
                .ConfigureRunner(c => c
                    .AddPostgres()
                    .WithGlobalConnectionString(dbConfiguration.ConnectionString)
                    .ScanIn(assembly).For.All());

            return services;
        }
    }
}