using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;
using Release.Helper;

namespace Prod.RutaDigital.Core.Aplicacion.Procesos;

public class WeatherForecastProceso : AccionGenerica<WeatherForecastRequest>
{
    private IUnitOfWork _uow;

    public WeatherForecastProceso(IUnitOfWork uow)
    {
        _uow = uow;
    }

    protected override StatusResponse 
        Registrar(WeatherForecastRequest request)
    {
        var sr = new StatusResponse { Data = 0 };

        return sr;
    }
}
