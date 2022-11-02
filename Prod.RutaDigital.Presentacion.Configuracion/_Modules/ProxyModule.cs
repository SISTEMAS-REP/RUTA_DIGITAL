using Autofac;
using System.Reflection;

namespace Prod.RutaDigital.Presentacion.Configuracion._Modules;

public class ProxyModule : Autofac.Module
{
    public static AppConfig AppConfig;
    
    protected override void Load(ContainerBuilder builder)
    {
        /*builder
            .Register(c => c.Resolve<IHttpClientFactory>().CreateClient())
            .As<HttpClient>();*/

        //Proxy Local
        builder
            .RegisterAssemblyTypes(Assembly.Load(new AssemblyName("Prod.RutaDigital.Presentacion.Configuracion")))
            .Where(type => type.Name.EndsWith("Proxy", StringComparison.Ordinal))
            .AsSelf();

        //Proxy Externos

        base.Load(builder);
    }
}
