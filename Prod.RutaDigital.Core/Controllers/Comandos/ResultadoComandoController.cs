using Release.Helper;
using Microsoft.AspNetCore.Mvc;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Controllers.Consultas;

[ApiController]
[Route("[controller]")]
public class ResultadoComandoController : ControllerBase
{
    private readonly IResultadoAplicacion _resultadoAplicacion;

    public ResultadoComandoController(IResultadoAplicacion resultadoAplicacion)
    {
        _resultadoAplicacion = resultadoAplicacion;
    }

    [HttpPost]
    [Route("InsertarResultado")]
    public async Task<StatusResponse<int>>
        InsertarResultado(ResultadoRequest request)
    {
        return await _resultadoAplicacion
            .InsertarResultado(request);
    }
}
