using Release.Helper;
using Microsoft.AspNetCore.Mvc;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Controllers.Consultas;

[ApiController]
[Route("[controller]")]
public class PreguntaConsultaController : ControllerBase
{
    private readonly IPreguntaAplicacion _preguntaAplicacion;

    public PreguntaConsultaController(IPreguntaAplicacion preguntaAplicacion)
    {
        _preguntaAplicacion = preguntaAplicacion;
    }

    [HttpGet]
    [Route("ListarPreguntas")]
    public async Task<StatusResponse<IEnumerable<PreguntaResponse>>> 
        ListarPreguntas(PreguntaRequest request)
    {
        return await _preguntaAplicacion
            .ListarPreguntas(request);
    }
}
