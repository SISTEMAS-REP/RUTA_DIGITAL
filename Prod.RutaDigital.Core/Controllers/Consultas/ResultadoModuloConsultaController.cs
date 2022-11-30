using Release.Helper;
using Microsoft.AspNetCore.Mvc;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Controllers.Consultas;

[ApiController]
[Route("[controller]")]
public class ResultadoModuloConsultaController : ControllerBase
{
    private readonly IResultadoModuloAplicacion _resultadoModuloAplicacion;

    public ResultadoModuloConsultaController(IResultadoModuloAplicacion resultadoModuloAplicacion)
    {
        _resultadoModuloAplicacion = resultadoModuloAplicacion;
    }

    [HttpGet]
    [Route("ListarResultadoModulos")]
    public async Task<StatusResponse<IEnumerable<ResultadoModuloResponse>>> 
        ListarResultadoModulos(ResultadoModuloRequest request)
    {
        return await _resultadoModuloAplicacion
            .ListarResultadoModulos(request);
    }

    [HttpGet]
    [Route("ListarResultadoModulosHistorico")]
    public async Task<StatusResponse<IEnumerable<ResultadoModuloResponse>>>
        ListarResultadoModulosHistorico(ResultadoModuloRequest request)
    {
        return await _resultadoModuloAplicacion
            .ListarResultadoModulosHistorico(request);
    }
}
