using Autofac;
using Prod.LoginUnico.Presentacion.Configuracion.Extra;

namespace Prod.RutaDigital.Presentacion.Configuracion._Modules;

public class ExtraModule : Module
{
    protected override void
        Load(ContainerBuilder builder)
    {
        builder
            .RegisterType<CurrentUserService>();

        base.Load(builder);
    }
}
