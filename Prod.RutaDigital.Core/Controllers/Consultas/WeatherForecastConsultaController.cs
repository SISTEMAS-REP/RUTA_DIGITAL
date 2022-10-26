using Microsoft.AspNetCore.Mvc;
using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Entidades;
using Release.Helper;

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
    [Route("Listar")]
    public async Task<StatusResponse<List<WeatherForecastResponse>>>
        Listar([FromQuery] WeatherForecastRequest request)
    {
        return await _weatherForecastAplicacion
            .Listar(request);
    }
}