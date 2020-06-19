using CzTrainApi.Db;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace CzTrainApi.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var logger = host.Services.GetRequiredService<ILogger<Program>>();

                using (var context = scope.ServiceProvider.GetRequiredService<DatenbankContext>())
                {
                    try
                    {
                        logger.LogInformation("Starte Migration!");
                        context.Database.Migrate();
                        DatenbankSeeder.Seed(context);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "Fehler beim starten!");
                        throw;
                    }
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.ClearProviders();
                    logging.AddDebug();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
