using Autofac;

namespace Prod.RutaDigital.Core.Api.App_Start;

public static class BootstrapperContainer
{
    public static void 
        Register(ContainerBuilder builder, IConfiguration configuration)
    {
        //Proxy
        ProxyModule.Configuration = configuration;
        builder.RegisterModule<ProxyModule>();

        //Add Context
        ContextDbModule.Configuration = configuration;
        builder.RegisterModule<ContextDbModule>();
    }
}
