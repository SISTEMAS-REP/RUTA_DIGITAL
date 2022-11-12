using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Prod.RutaDigital.Presentacion.Configuracion._Modules;
using Serilog;
using System.Text.Json.Serialization;

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

builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

builder.Services
    .AddHttpContextAccessor();

#region cookie
builder.Services
    .AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(builder.Configuration
        .GetSection("SecuritySettings:KeyDirectory").Value))
    .SetApplicationName(builder.Configuration
        .GetSection("SecuritySettings:ApplicationName").Value);

builder.Services
    .AddAuthentication(o =>
    {
        o.DefaultScheme = IdentityConstants.ApplicationScheme;
        o.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddCookie(IdentityConstants.ApplicationScheme, options =>
    {
        options.Cookie.Name = builder.Configuration
        .GetSection("SecuritySettings:CookieName").Value;
        options.Cookie.SameSite = SameSiteMode.Lax;
        options.Cookie.Domain = builder.Configuration
        .GetSection("SecuritySettings:DomainSecure").Value;
        options.Events.OnRedirectToLogin = context =>
        {
            context.Response.StatusCode = 401;
            return Task.CompletedTask;
        };
    });

/*builder.Services
    .ConfigureApplicationCookie(options =>
    {
        options.Cookie.Name = ".AspNet.SharedCookie.Extranet";
        options.Cookie.SameSite = SameSiteMode.Lax;
    });*/
#endregion cookie

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

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
