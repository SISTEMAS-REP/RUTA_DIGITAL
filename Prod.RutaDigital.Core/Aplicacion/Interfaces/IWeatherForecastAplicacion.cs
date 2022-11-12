using Prod.RutaDigital.Entidades;
using Release.Helper;

namespace Prod.RutaDigital.Core.Aplicacion.Interfaces;

public interface IWeatherForecastAplicacion
{
    Task<StatusResponse<IEnumerable<WeatherForecastResponse>>>
        ListarWeatherForecast(WeatherForecastRequest request);
}
