using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prod.RutaDigital.Entidades;
using Prod.RutaDigital.Presentacion.Configuracion;
using Prod.RutaDigital.Presentacion.Configuracion.Proxys;
using Release.Helper;

namespace Prod.RutaDigital.Presentacion.Angular.Controllers;

[AllowAnonymous]
[ApiController]
[Route("[controller]")]
public class EventosController : ControllerBase
{
    private readonly EventoConsultaProxy _eventoConsultaProxy;
    private readonly AppVariables _appVariables;

    public EventosController(EventoConsultaProxy eventoConsultaProxy,
           AppVariables appVariables)
    {
        _eventoConsultaProxy = eventoConsultaProxy;
        _appVariables = appVariables;
    }

    [HttpGet("ListarEventos")]
    public async Task<IActionResult> 
        ListarEvento([FromQuery] EventoRequest request)
    {

        var response = await _eventoConsultaProxy
          .ListarEventos(request);
        var data = response.Data
        .Select(s =>
        {
                var fotoPath = Path.Combine(_appVariables.RutaArchivos, s.foto!);
                byte[]? numArray;

                try
                {
                    numArray = System.IO.File.ReadAllBytes(fotoPath);
                }
                catch
                {
                    numArray = null;
            }
            s.numArray = numArray;

                return s;
            });

        var result = new StatusResponse<IEnumerable<EventoResponse>>()
        {
            Success = true,
            Data = data
        };

        return Ok(result);
    }
}
