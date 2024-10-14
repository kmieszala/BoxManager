using System.IO;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Aplitt.NEXTA.Studio.WebUI;

public class Program
{
    public static void Main(string[] args)
    {
        var config = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                       .AddUserSecrets<Program>()
                       .AddCommandLine(args)
                       .Build();

        CreateHostBuilder(args)
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders();  // Usuwamy domyœlnych dostawców logowania
                logging.AddConsole();      // Dodajemy dostawcê logowania do konsoli
                logging.SetMinimumLevel(LogLevel.Information); // Ustawiamy minimalny poziom logowania (np. Informacje)
            })
            .Build()
            .Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>()
                //.UseKestrel()
                .UseIISIntegration()
                .UseUrls();
            });
}

//public class Program
//{
//    public static void Main(string[] args)
//    {
//        var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

//        var config = new ConfigurationBuilder()
//                    .SetBasePath(Directory.GetCurrentDirectory())
//                    .AddJsonFile($"appsettings.json")
//                    .Build();

//        try
//        {
//            CreateHostBuilder(args).Build().Run();
//        }
//        catch (System.Exception ex)
//        {
//            Trace.WriteLine(ex);
//        }
//        finally
//        {
//        }
//    }

//    public static IHostBuilder CreateHostBuilder(string[] args) =>
//         Host.CreateDefaultBuilder(args)
//         .ConfigureAppConfiguration((hostingContext, config) =>
//         {
//             config.AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true);
//             if (hostingContext.HostingEnvironment.IsDevelopment())
//             {
//                 config.AddUserSecrets<Program>();
//             }

//             config.AddEnvironmentVariables(prefix: "NX_");

//             foreach (var c in config.Build().AsEnumerable().ToList())
//             {
//                 //Log.Debug($"{c.Key}: {c.Value}");
//             }
//         })
//         .ConfigureWebHostDefaults(webBuilder =>
//         {
//             webBuilder.UseStartup<Startup>();
//         });
//}