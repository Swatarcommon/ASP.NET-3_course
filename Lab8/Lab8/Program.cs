using Lab8;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.IO;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;


namespace Lab8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}




/*
namespace Lab8
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
            .AddEnvironmentVariables()
             .AddCommandLine(args)
             .AddJsonFile("appsettings.json")
              .Build(); //Создаём нашу конфигурацию


            var host = new WebHostBuilder()
            .UseKestrel() // настраивает веб-сервер Kestrel
            .UseConfiguration(configuration) //загружаем конфигурацию
            .UseContentRoot(Directory.GetCurrentDirectory()) // настраивает корневой каталог приложения
            .UseIISIntegration() // обеспечивает интеграцию с IIS
            .UseStartup<Startup>() //устанавливает главный файл приложения
            .ConfigureLogging((hostingContext, logging) => //включить системный протоколирование
            {
                logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                logging.AddConsole();
                logging.AddDebug();
            }) 
            .Build(); //создаёт хост
            host.Run();
        }
    }
}
*/
