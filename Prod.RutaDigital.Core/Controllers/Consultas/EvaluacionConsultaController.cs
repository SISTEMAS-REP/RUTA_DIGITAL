using Release.Helper;
using Microsoft.AspNetCore.Mvc;
using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Controllers.Consultas;

[ApiController]
[Route("[controller]")]
public class EvaluacionConsultaController : ControllerBase
{
    private readonly IEvaluacionAplicacion _evaluacionAplicacion;

    public EvaluacionConsultaController(IEvaluacionAplicacion evaluacionAplicacion)
    {
        _evaluacionAplicacion = evaluacionAplicacion;
    }

    [HttpGet]
    [Route("ListarEvaluacion")]
    public async Task<StatusResponse<IEnumerable<EvaluacionResponse>>> 
        ListarEvaluacion(EvaluacionRequest request)
    {
        return await _evaluacionAplicacion
            .ListarEvaluacion(request);
    }

    [HttpGet]
    [Route("ListarEvaluacionHistorico")]
    public async Task<StatusResponse<IEnumerable<EvaluacionResponse>>>
        ListarEvaluacionHistorico(EvaluacionRequest request)
    {
        return await _evaluacionAplicacion
            .ListarEvaluacionHistorico(request);
    }
}
