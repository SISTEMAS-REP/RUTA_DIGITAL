using Autofac;
using Prod.RutaDigital.Datos;
using Prod.RutaDigital.Datos.Comun;
using Prod.RutaDigital.Datos.Contexto;
using Prod.RutaDigital.Datos.Interfaces;
using Release.Helper.Data.Core;
using System.Reflection;

namespace Prod.RutaDigital.Core.Api.App_Start;

public class ContextDbModule : Autofac.Module
{
    public static IConfiguration Configuration;

    protected override void 
        Load(ContainerBuilder builder)
    {
        string connectionString = Configuration.GetSection("ConnectionStrings:RutaDigitalDbContext").Value;

        //Context           
        builder
            .RegisterType<RutaDbContext>()
            .Named<IDbContext>("context")
            .WithParameter("connstr", connectionString).InstancePerLifetimeScope();

        /*builder
            .RegisterType<UnitOfWork>()
            .As<IUnitOfWork>()
            .WithParameter((c, p) => true, (c, p) => p.ResolveNamed<IDbContext>("context"));*/

        builder
            .RegisterType<PokemonUnitOfWork>()
            .As<IPokemonUnitOfWork>()
            .WithParameter((c, p) => true, (c, p) => p.ResolveNamed<IDbContext>("context"));

        builder
            .RegisterType<WeatherForecastUnitOfWork>()
            .As<IWeatherForecastUnitOfWork>()
            .WithParameter((c, p) => true, (c, p) => p.ResolveNamed<IDbContext>("context"));

        builder
          .RegisterType<BannerUnitOfWork>()
          .As<IBannerUnitOfWork>()
          .WithParameter((c, p) => true, (c, p) => p.ResolveNamed<IDbContext>("context"));

        //-> Aplicacion
        builder.RegisterAssemblyTypes(Assembly.Load(new AssemblyName("Prod.RutaDigital.Core")))
            .Where(t => t.Name.EndsWith("Aplicacion", StringComparison.Ordinal) && t.GetTypeInfo().IsClass)
            .AsImplementedInterfaces();

        //-> Validacion
        builder.RegisterAssemblyTypes(Assembly.Load(new AssemblyName("Prod.RutaDigital.Core")))
            .Where(t => t.Name.EndsWith("Validacion", StringComparison.Ordinal) && t.GetTypeInfo().IsClass)
            .AsSelf();

        //-> Proceso
        builder.RegisterAssemblyTypes(Assembly.Load(new AssemblyName("Prod.RutaDigital.Core")))
            .Where(t => t.Name.EndsWith("Proceso", StringComparison.Ordinal) && t.GetTypeInfo().IsClass)
            .AsSelf();
    }
}
