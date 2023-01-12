using app.application.conapp.Services;
using core.application.lib.Interfaces;
using core.application.lib.Models.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using static core.application.lib.Models.Common.Constants;

namespace app.application.conapp;

static class Program
{
    static void Main(string[] args)
    {        
        var builder = new ConfigurationBuilder();
        BuildConfig(builder);

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Build())
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();

        Log.Logger.Information("Application Starting");

        var host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddOptions<GSheetOptions>().Bind(context.Configuration.GetSection(ConfigSections.GSheetSection));
                services.AddTransient<IGSheetService, GSheetService>();
                services.AddTransient<IDataServiceSqlServer, DataServiceSqlServer>();
            })
            .UseSerilog()
            .Build();       

        var app = ActivatorUtilities.CreateInstance<GSheetApp>(host.Services);
        app.Run();
    }

    static void BuildConfig(IConfigurationBuilder builder)
    {
        builder.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")??"Production"}.json", optional: true)
            .AddEnvironmentVariables();
    }
}
