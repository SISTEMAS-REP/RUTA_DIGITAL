using Autofac.Extensions.DependencyInjection;
using Autofac;
using Microsoft.AspNetCore.Mvc;
using Prod.RutaDigital.Presentacion.Configuracion._Modules;
using Serilog;
using Autofac.Core;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddHttpClient();

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

builder.Services
    .AddHttpContextAccessor()
    .AddResponseCompression();

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new ProducesAttribute("application/json"));
});

builder.Services
    .AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo("C:/Key"))
    .SetApplicationName("SharedCookieApp");

builder.Services
    .AddAuthentication(o =>
    {
        o.DefaultScheme = IdentityConstants.ApplicationScheme;
        o.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddCookie(IdentityConstants.ApplicationScheme, options =>
    {
        options.Cookie.Name = ".AspNet.SharedCookie.Extranet";
        //options.EventsType = typeof(CustomCookieAuthenticationEvents);
    });

builder.Services
    .ConfigureApplicationCookie(options =>
    {
        options.Cookie.Name = ".AspNet.SharedCookie.Extranet";
        options.Cookie.SameSite = SameSiteMode.Lax;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.Use(async (context, next) =>
{
    context.Response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
    await next();
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
