using Serilog;
using Serilog.Events;
using Serilog.Expressions;
using Serilog.Settings.Configuration;
using ServiceVacanciesAndResumes.API.Infrastructure.Repositories;
using System.Reflection;
using System.Runtime.InteropServices;

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
                    .Enrich.WithMemoryUsage()
                    .Enrich.WithMachineName()
                    .Enrich.WithThreadId()
                    .Enrich.WithEnvironmentName()
                    .Enrich.WithEnvironmentUserName()
                    .Enrich.WithClientIp()
                    .WriteTo.File(@"logs\logs-.txt", LogEventLevel.Information, rollingInterval: RollingInterval.Day, retainedFileCountLimit: 60)
                    .WriteTo.Console());

    builder.Services.AddScoped<IVacanciesRepository, VacanciesRepository>();
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "ServiceVacanciesAndResumes.API");
            c.RoutePrefix = string.Empty;  
        });
    }
    app.MapControllers();
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