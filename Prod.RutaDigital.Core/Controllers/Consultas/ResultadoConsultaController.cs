using Release.Helper;
using Microsoft.AspNetCore.Mvc;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Controllers.Consultas;

[ApiController]
[Route("[controller]")]
public class ResultadoConsultaController : ControllerBase
{
    private readonly IResultadoAplicacion _ResultadoAplicacion;

    public ResultadoConsultaController(IResultadoAplicacion ResultadoAplicacion)
    {
        _ResultadoAplicacion = ResultadoAplicacion;
    }

    [HttpGet]
    [Route("ListarResultados")]
    public async Task<StatusResponse<IEnumerable<ResultadoResponse>>> 
        ListarResultados(ResultadoRequest request)
    {
        return await _ResultadoAplicacion
            .ListarResultados(request);
    }
}
