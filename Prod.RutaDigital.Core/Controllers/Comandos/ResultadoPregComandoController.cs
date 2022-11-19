using Release.Helper;
using Microsoft.AspNetCore.Mvc;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Controllers.Consultas;

[ApiController]
[Route("[controller]")]
public class ResultadoPregComandoController : ControllerBase
{
    private readonly IResultadoPregAplicacion _resultadoPregAplicacion;

    public ResultadoPregComandoController(IResultadoPregAplicacion resultadoPregAplicacion)
    {
        _resultadoPregAplicacion = resultadoPregAplicacion;
    }

    [HttpPost]
    [Route("InsertarResultadoPreg")]
    public async Task<StatusResponse<int>>
        InsertarResultadoPreg(ResultadoPregRequest request)
    {
        return await _resultadoPregAplicacion
            .InsertarResultadoPreg(request);
    }
}
