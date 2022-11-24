using Release.Helper;
using Microsoft.AspNetCore.Mvc;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Controllers.Consultas;

[ApiController]
[Route("[controller]")]
public class RecursoConsultaController : ControllerBase
{
    private readonly IRecursoAplicacion _RecursoAplicacion;

    public RecursoConsultaController(IRecursoAplicacion RecursoAplicacion)
    {
        _RecursoAplicacion = RecursoAplicacion;
    }

    [HttpGet]
    [Route("ListarRecursos")]
    public async Task<StatusResponse<IEnumerable<RecursoResponse>>>
        ListarRecursos(RecursoRequest request)
    {
        return await _RecursoAplicacion
            .ListarRecursos(request);
    }
}
