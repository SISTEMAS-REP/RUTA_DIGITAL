using Release.Helper;
using Microsoft.AspNetCore.Mvc;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Controllers.Consultas;

[ApiController]
[Route("[controller]")]
public class EvaluacionComandoController : ControllerBase
{
    private readonly IEvaluacionAplicacion _evaluacionAplicacion;

    public EvaluacionComandoController(IEvaluacionAplicacion evaluacionAplicacion)
    {
        _evaluacionAplicacion = evaluacionAplicacion;
    }

    [HttpPost]
    [Route("InsertarEvaluacion")]
    public async Task<StatusResponse<int>>
        InsertarEvaluacion(EvaluacionRequest request)
    {
        return await _evaluacionAplicacion
            .InsertarEvaluacion(request);
    }

    [HttpPut]
    [Route("ActualizarEvaluacion")]
    public async Task<StatusResponse<int>>
        ActualizarEvaluacion(EvaluacionRequest request)
    {
        return await _evaluacionAplicacion
            .ActualizarEvaluacion(request);
    }
}
