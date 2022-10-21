using Prod.RutaDigital.Datos.Comun;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Datos.Interfaces;

public interface IWeatherForecastUnitOfWork : IUnitOfWork
{
    Task<IEnumerable<WeatherForecastResponse>>
        Listar(WeatherForecastRequest request);
}
