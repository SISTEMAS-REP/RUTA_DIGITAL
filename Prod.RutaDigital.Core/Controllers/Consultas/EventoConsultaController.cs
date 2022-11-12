using Release.Helper;
using Microsoft.AspNetCore.Mvc;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Controllers.Consultas;

[ApiController]
[Route("[controller]")]
public class EventoConsultaController : ControllerBase
{
    private readonly IEventoAplicacion _eventoAplicacion;

    public EventoConsultaController(IEventoAplicacion eventoAplicacion)
    {
        _eventoAplicacion = eventoAplicacion;
    }

    [HttpGet]
    [Route("ListarEventos")]
    public async Task<StatusResponse<IEnumerable<EventoResponse>>> 
        ListarEventos(EventoRequest request)
    {
        return await _eventoAplicacion
            .ListarEventos(request);
    }
}
