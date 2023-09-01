using Microsoft.Extensions.Options;
using MudBlazor.Services;
using ProtoBuf.Grpc.ClientFactory;
using Serilog;
using Serilog.Events;
using Serilog.Expressions;
using Serilog.Settings.Configuration;
using ServiceVacanciesAndResumes.IGrpcService;
using System.Reflection;
using System.Runtime.InteropServices;
using WebViewVacanciesAndResumes.Infrastructure;
using WebViewVacanciesAndResumes.Models;

IConfiguration Configuration = new ConfigurationBuilder()
   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
   .AddEnvironmentVariables()
   .Build();

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    var options = new ConfigurationReaderOptions(typeof(ConsoleLoggerConfigurationExtensions).Assembly, typeof(SerilogExpression).Assembly);
    builder.Host.UseSerilog((context, services, configuration) => configuration
                    .ReadFrom.Configuration(context.Configuration, options)
                    .ReadFrom.Services(services)
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                    .Enrich.WithProperty("ApplicationName", Assembly.GetExecutingAssembly().GetName().Name)
                    .Enrich.WithProperty("Version", Assembly.GetExecutingAssembly().GetName().Version)
                    .Enrich.WithProperty("OS Version", RuntimeInformation.OSDescription)
                    .Enrich.WithProperty("UsedStore", "")
                    .Enrich.WithMemoryUsage()
                    .Enrich.WithMachineName()
                    .Enrich.WithThreadId()
                    .Enrich.WithEnvironmentName()
                    .Enrich.WithEnvironmentUserName()
                    .Enrich.WithClientIp()
                    .WriteTo.File(@"logs\logs-.txt", LogEventLevel.Information, rollingInterval: RollingInterval.Day, retainedFileCountLimit: 60)
                    .WriteTo.Console());

    builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor();
    builder.Services.AddMudServices();
    builder.Services.AddSingleton<FilterRequest>();

    builder.Services.AddTransient<GrpcExceptionInterceptor>();
    builder.Services.AddCodeFirstGrpcClient<IGrpcService>((services, options) =>
    {
        options.Address = new Uri("http://localhost:15011");
    }).AddInterceptor<GrpcExceptionInterceptor>();

    var app = builder.Build();

    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.UseStaticFiles();

    app.UseRouting();

    app.MapBlazorHub();
    app.MapFallbackToPage("/_Host");

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.Logger.Information("Close Program");
    Log.CloseAndFlush();
}