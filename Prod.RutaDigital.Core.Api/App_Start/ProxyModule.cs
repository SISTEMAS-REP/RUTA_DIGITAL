using Autofac;

namespace Prod.RutaDigital.Core.Api.App_Start;

public class ProxyModule : Autofac.Module
{
    public static IConfiguration Configuration;

    protected override void 
        Load(ContainerBuilder builder)
    {
        //Proxy

        base.Load(builder);
    }
}
