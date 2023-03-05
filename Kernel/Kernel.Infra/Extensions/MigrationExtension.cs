using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Kernel.Infra.Extensions
{
    public static class MigrationExtension
    {
        public static IHost MigrateDatabase<T>(this IHost host) where T : DbContext
        {
            using (var scope = host.Services.CreateScope())
            {
                Console.WriteLine("Initialize Migration");
                using (var appContext = scope.ServiceProvider.GetRequiredService<T>())
                {
                    try
                    {
                        appContext.Database.Migrate();
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception);
                        return host;
                    }
                }
            }

            Console.WriteLine("Done");
            return host;
        }
    }
}