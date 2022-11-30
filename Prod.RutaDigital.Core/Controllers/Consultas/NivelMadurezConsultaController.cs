using Release.Helper;
using Microsoft.AspNetCore.Mvc;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Controllers.Consultas;

[ApiController]
[Route("[controller]")]
public class NivelMadurezConsultaController : ControllerBase
{
    private readonly INivelMadurezAplicacion _nivelMadurezAplicacion;

    public NivelMadurezConsultaController(INivelMadurezAplicacion nivelMadurezAplicacion)
    {
        _nivelMadurezAplicacion = nivelMadurezAplicacion;
    }

    [HttpGet]
    [Route("ListarNivelesMadurez")]
    public async Task<StatusResponse<IEnumerable<NivelMadurezResponse>>>
        ListarNivelesMadurez()
    {
        return await _nivelMadurezAplicacion
            .ListarNivelesMadurez();
    }

    [HttpGet]
    [Route("ListarNivelesMadurezHistorico")]
    public async Task<StatusResponse<IEnumerable<NivelMadurezResponse>>>
        ListarNivelesMadurezHistorico()
    {
        return await _nivelMadurezAplicacion
            .ListarNivelesMadurezHistorico();
    }
}
