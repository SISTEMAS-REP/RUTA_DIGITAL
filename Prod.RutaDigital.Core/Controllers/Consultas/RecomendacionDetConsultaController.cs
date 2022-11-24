using Release.Helper;
using Microsoft.AspNetCore.Mvc;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Controllers.Consultas;

[ApiController]
[Route("[controller]")]
public class RecomendacionDetConsultaController : ControllerBase
{
    private readonly IRecomendacionDetAplicacion _recomendacionDetAplicacion;

    public RecomendacionDetConsultaController(IRecomendacionDetAplicacion recomendacionDetAplicacion)
    {
        _recomendacionDetAplicacion = recomendacionDetAplicacion;
    }

    [HttpGet]
    [Route("ListarRecomendacionDetalles")]
    public async Task<StatusResponse<IEnumerable<RecomendacionDetResponse>>>
        ListarRecomendacionDetalles(RecomendacionDetRequest request)
    {
        return await _recomendacionDetAplicacion
            .ListarRecomendacionDetalles(request);
    }
}
