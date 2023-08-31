using Microsoft.AspNetCore.Server.Kestrel.Core;
using ProtoBuf.Grpc.Server;
using Serilog;
using Serilog.Events;
using Serilog.Expressions;
using Serilog.Settings.Configuration;
using ServiceVacanciesAndResumes.API;
using ServiceVacanciesAndResumes.API.Grpc;
using ServiceVacanciesAndResumes.API.Infrastructure;
using ServiceVacanciesAndResumes.API.Infrastructure.Repositories;
using System.Net;
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

    builder.WebHost.ConfigureKestrel(options =>
    {
        var ports = GetDefinedPorts(Configuration);
        options.Listen(IPAddress.Any, ports.httpPort, listenOptions =>
        {
            listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
        });

        options.Listen(IPAddress.Any, ports.grpcPort, listenOptions =>
        {
            listenOptions.Protocols = HttpProtocols.Http2;
        });

    });

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

    builder.Services.AddDbContext<ServiceVacanciesAndResumesContext>();
    builder.Services.AddScoped<IVacanciesRepository, VacanciesRepository>();
    builder.Services.AddScoped<IResumesRepository, ResumesRepository>();

    builder.Services.AddGrpc();
    builder.Services.AddCodeFirstGrpc();
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    var app = builder.Build();

    app.MapGrpcService<GrpcApiService>();
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

    using (var scope = app.Services.CreateScope())
    {
        await SeedData.EnsureSeedData(scope, app.Configuration, app.Logger);
    }
    await app.RunAsync();
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

(int httpPort, int grpcPort) GetDefinedPorts(IConfiguration config)
{
    var grpcPort = config.GetValue("GRPC_PORT", 15011);
    var port = config.GetValue("PORT", 15010);
    return (port, grpcPort);
}