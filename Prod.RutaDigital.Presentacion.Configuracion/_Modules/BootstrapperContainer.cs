using Autofac;
using Microsoft.Extensions.Configuration;

namespace Prod.RutaDigital.Presentacion.Configuracion._Modules;

public class BootstrapperContainer
{
    public static void Register(ContainerBuilder builder, 
        IConfiguration configuration)
    {
        //Variables
        var appConfig = new AppConfig();
        configuration.GetSection("AppConfig").Bind(appConfig);
        builder.Register(c => appConfig);

        var appVariables = new AppVariables();
        configuration.GetSection("AppConfig:AppVariables").Bind(appVariables);
        builder.Register(c => appVariables);

        var appAuditoria = new AppAuditoria();
        configuration.GetSection("AppConfig:AppAuditoria").Bind(appAuditoria);
        builder.Register(c => appAuditoria);

        //Proxys  
        ProxyModule.AppConfig = appConfig;
        builder.RegisterModule<ProxyModule>();
    }
}
