using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Prod.RutaDigital.Core.Api.App_Start;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(containerBuilder =>
    {
        BootstrapperContainer
            .Register(containerBuilder, builder.Configuration);
    });

var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

var basePath = AppDomain.CurrentDomain.BaseDirectory; //#SDK 2.00

var configBuilder = new ConfigurationBuilder()
    .SetBasePath(basePath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{env ?? "Production"}.json", optional: true)
    .AddEnvironmentVariables()
    .Build();

builder.WebHost.UseConfiguration(configBuilder);

builder.Host.UseSerilog();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

// Add services to the container.

builder.Services
    .AddControllers(options =>
    {
        options.Filters.Add(new ProducesAttribute("application/json"));
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
//app.Run(context => context.Response.WriteAsync($"<h1 style='color:blue;'>Prod.RutaDigital.Core.API Environment: {env.EnvironmentName}</h1>"));
