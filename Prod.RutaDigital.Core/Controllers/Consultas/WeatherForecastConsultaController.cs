using Release.Helper;
using Microsoft.AspNetCore.Mvc;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Controllers.Consultas;

//[ApiController]
[Route("[controller]")]
public class WeatherForecastConsultaController : ControllerBase
{
    private readonly IWeatherForecastAplicacion _weatherForecastAplicacion;

    public WeatherForecastConsultaController(IWeatherForecastAplicacion weatherForecastAplicacion)
    {
        _weatherForecastAplicacion = weatherForecastAplicacion;
    }

    [HttpGet]
    [Route("ListarWeatherForecast")]
    public async Task<StatusResponse<IEnumerable<WeatherForecastResponse>>>
        ListarWeatherForecast(WeatherForecastRequest request)
    {
        return await _weatherForecastAplicacion
            .ListarWeatherForecast(request); 
    }
}