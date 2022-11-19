using Release.Helper;
using Microsoft.AspNetCore.Mvc;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Controllers.Consultas;

[ApiController]
[Route("[controller]")]
public class RespuestaConsultaController : ControllerBase
{
    private readonly IRespuestaAplicacion _respuestaAplicacion;

    public RespuestaConsultaController(IRespuestaAplicacion respuestaAplicacion)
    {
        _respuestaAplicacion = respuestaAplicacion;
    }

    [HttpGet]
    [Route("ListarRespuestas")]
    public async Task<StatusResponse<IEnumerable<RespuestaResponse>>> 
        ListarRespuestas(RespuestaRequest request)
    {
        return await _respuestaAplicacion
            .ListarRespuestas(request);
    }
}
