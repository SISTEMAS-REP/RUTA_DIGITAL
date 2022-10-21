using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prod.RutaDigital.Entidades;
using Prod.RutaDigital.Presentacion.Configuracion.Proxys;

namespace Prod.RutaDigital.Presentacion.Angular.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly WeatherForecastConsultaProxy _weatherForecastConsulta;

    public WeatherForecastController(WeatherForecastConsultaProxy weatherForecastConsulta)
    {
        _weatherForecastConsulta = weatherForecastConsulta;
    }

    [HttpGet]
    public async Task<IActionResult> 
        GetWeatherForecasts([FromQuery] WeatherForecastRequest request)
    {
        var result = await _weatherForecastConsulta
            .Listar(request);
        return Ok(result);
    }
}