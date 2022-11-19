using Release.Helper;
using Microsoft.AspNetCore.Mvc;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Controllers.Consultas;

[ApiController]
[Route("[controller]")]
public class RecomendacionConsultaController : ControllerBase
{
    private readonly IRecomendacionAplicacion _recomendacionAplicacion;

    public RecomendacionConsultaController(IRecomendacionAplicacion recomendacionAplicacion)
    {
        _recomendacionAplicacion = recomendacionAplicacion;
    }

    [HttpGet]
    [Route("ListarRecomendaciones")]
    public async Task<StatusResponse<IEnumerable<RecomendacionResponse>>>
        ListarRecomendaciones(RecomendacionRequest request)
    {
        return await _recomendacionAplicacion
            .ListarRecomendaciones(request);
    }
}
