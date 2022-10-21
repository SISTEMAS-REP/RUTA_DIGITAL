using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;
using Release.Helper;

namespace Prod.RutaDigital.Core.Aplicacion.Validacion;

public class WeatherForecastValidacion : ValidacionGenerica
{
    private IWeatherForecastUnitOfWork _uow;

    public WeatherForecastValidacion(IWeatherForecastUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<List<string>>
        Validar(WeatherForecastRequest request)
    {
        /*if (string.IsNullOrWhiteSpace(request.))
        {
            Msg.Add("Es un valor requerido");
        }*/

        return await Task.FromResult(Msg);
    }
}
