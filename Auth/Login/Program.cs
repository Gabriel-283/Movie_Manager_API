using Kernel.Infra.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Movie.Login.API.Data.EfCore;

namespace Movie.Login.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
          CreateHostBuilder(args).Build().MigrateDatabase<UserDbContext>().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureAppConfiguration((context,builder) => builder.AddUserSecrets<Program>());
    }
}
