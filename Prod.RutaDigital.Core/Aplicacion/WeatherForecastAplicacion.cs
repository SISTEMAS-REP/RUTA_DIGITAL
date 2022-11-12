using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;
using Release.Helper;

namespace Prod.RutaDigital.Core.Aplicacion;

public class WeatherForecastAplicacion : IWeatherForecastAplicacion
{
    private IUnitOfWork _uow;

    public WeatherForecastAplicacion(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<StatusResponse<IEnumerable<WeatherForecastResponse>>>
        ListarWeatherForecast(WeatherForecastRequest request)
    {
        var resultado = new StatusResponse<IEnumerable<WeatherForecastResponse>>();

        try
        {
            var data = await _uow
                .ListarWeatherForecast(request);

            resultado.Success = true;
            resultado.Data = data.ToList();
        }
        catch (Exception ex)
        {
            resultado.Success = true;
            resultado.Messages = new()
            {
                ex.Message
            };
        }

        return resultado;
    }
}