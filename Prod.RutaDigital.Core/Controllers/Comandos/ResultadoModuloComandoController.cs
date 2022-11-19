using Release.Helper;
using Microsoft.AspNetCore.Mvc;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Controllers.Consultas;

[ApiController]
[Route("[controller]")]
public class ResultadoModuloComandoController : ControllerBase
{
    private readonly IResultadoModuloAplicacion _resultadoModuloAplicacion;

    public ResultadoModuloComandoController(IResultadoModuloAplicacion resultadoModuloAplicacion)
    {
        _resultadoModuloAplicacion = resultadoModuloAplicacion;
    }

    [HttpPost]
    [Route("InsertarResultadoModulo")]
    public async Task<StatusResponse<int>>
        InsertarResultadoModulo(ResultadoModuloRequest request)
    {
        return await _resultadoModuloAplicacion
            .InsertarResultadoModulo(request);
    }
}
