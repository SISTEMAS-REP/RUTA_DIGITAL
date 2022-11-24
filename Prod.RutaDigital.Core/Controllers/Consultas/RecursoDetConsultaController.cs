using Release.Helper;
using Microsoft.AspNetCore.Mvc;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Controllers.Consultas;

[ApiController]
[Route("[controller]")]
public class RecursoDetConsultaController : ControllerBase
{
    private readonly IRecursoDetAplicacion _RecursoDetAplicacion;

    public RecursoDetConsultaController(IRecursoDetAplicacion RecursoDetAplicacion)
    {
        _RecursoDetAplicacion = RecursoDetAplicacion;
    }

    [HttpGet]
    [Route("ListarRecursoDetalles")]
    public async Task<StatusResponse<IEnumerable<RecursoDetResponse>>>
        ListarRecursoDetalles(RecursoDetRequest request)
    {
        return await _RecursoDetAplicacion
            .ListarRecursoDetalles(request);
    }
}
