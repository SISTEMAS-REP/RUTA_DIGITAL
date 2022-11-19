using Release.Helper;
using Microsoft.AspNetCore.Mvc;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Controllers.Consultas;

[ApiController]
[Route("[controller]")]
public class RespuestaComandoController : ControllerBase
{
    private readonly IRespuestaAplicacion _respuestaAplicacion;

    public RespuestaComandoController(IRespuestaAplicacion respuestaAplicacion)
    {
        _respuestaAplicacion = respuestaAplicacion;
    }

    [HttpPost]
    [Route("InsertarRespuesta")]
    public async Task<StatusResponse<int>>
        InsertarRespuesta(RespuestaRequest request)
    {
        return await _respuestaAplicacion
            .InsertarRespuesta(request);
    }

    [HttpPut]
    [Route("ActualizarRespuesta")]
    public async Task<StatusResponse<int>>
        ActualizarRespuesta(RespuestaRequest request)
    {
        return await _respuestaAplicacion
            .ActualizarRespuesta(request);
    }
}
