using Serilog;
using Serilog.Events;
using Volo.Abp.Data;

namespace Doc.App;

public class Program
{
    public async static Task<int> Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Async(c => c.File("Logs/logs.txt"))
            .WriteTo.Async(c => c.Console())
            .CreateBootstrapLogger();

        try
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Host.AddAppSettingsSecretsJson()
                .UseAutofac()
                .UseSerilog((context, services, loggerConfiguration) =>
                {
                        loggerConfiguration
                        #if DEBUG
                            .MinimumLevel.Debug()
                        #else
                            .MinimumLevel.Information()
                        #endif
                            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                            .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
                            .Enrich.FromLogContext()
                            .WriteTo.Async(c => c.File("Logs/logs.txt"))
                            .WriteTo.Async(c => c.Console())
                            .WriteTo.Async(c => c.AbpStudio(services));
                    
                });
           
            await builder.AddApplicationAsync<AppModule>();
            var app = builder.Build();
            await app.InitializeApplicationAsync();            

            Log.Information("Starting Doc.App.");
            await app.RunAsync();
            return 0;
        }
        catch (Exception ex)
        {
            if (ex is HostAbortedException)
            {
                throw;
            }

            Log.Fatal(ex, "Doc.App terminated unexpectedly!");
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

}
