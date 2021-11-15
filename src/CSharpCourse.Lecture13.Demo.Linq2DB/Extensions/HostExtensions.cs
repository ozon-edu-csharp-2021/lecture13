using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CSharpCourse.Lecture13.Demo.Linq2DB.Extensions
{
    public static class HostExtensions
    {
        public static void RunWithMigrate(this IHost host, string[] args)
        {
            if (RunMigrate(args, out var dryRun))
                host.Migrate(dryRun);
            else
                host.Run();
        }

        private static bool RunMigrate(IReadOnlyList<string> args, out bool dryRun)
        {
            dryRun = false;
            if (args.Count == 0 || args[0] != "migrate")
                return false;
            if (args.Count > 1 && args[1] == "--dryrun")
                dryRun = true;
            return true;
        }

        private static void Migrate(this IHost host, bool dryRun)
        {
            using var scope = host.Services.CreateScope();
            var requiredService = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
            if (dryRun)
                requiredService.ListMigrations();
            else
                requiredService.MigrateUp();
        }
    }
}