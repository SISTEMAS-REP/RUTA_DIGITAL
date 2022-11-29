using Microsoft.AspNetCore.Mvc;
using Prod.RutaDigital.Core.Aplicacion;
using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Entidades;
using Release.Helper;

namespace Prod.RutaDigital.Core.Controllers.Consultas;

[ApiController]
[Route("[controller]")]
public class PerfilAvanceConsultaController : ControllerBase
{
    private readonly IPerfilAvanceAplicacion _perfilAvanceAplicacion;
    public PerfilAvanceConsultaController(IPerfilAvanceAplicacion perfilAvanceAplicacion)
    {
        _perfilAvanceAplicacion = perfilAvanceAplicacion;
    }


    [HttpGet]
    [Route("ListarEstadisticaPerfilAvance")]
    public async Task<StatusResponse<IEnumerable<PerfilAvanceEstadisticaResponse>>> ListarEstadisticaPerfilAvance(UsuarioExtranet request)
    {
        return await _perfilAvanceAplicacion
            .ListarEstadisticaPerfilAvance(request);
    }

    [HttpGet]
    [Route("ListarPremioConsumoPerfilAvance")]
    public async Task<StatusResponse<IEnumerable<PerfilAvancePremioConsumoResponse>>> ListarPremioConsumoPerfilAvance(UsuarioExtranet request)
    {
        return await _perfilAvanceAplicacion
            .ListarPremioConsumoPerfilAvance(request);
    }

    [HttpGet]
    [Route("ListarResultadosPerfilAvance")]
    public async Task<StatusResponse<IEnumerable<ResultadoResponse>>>
      ListarResultadosPerfilAvance(ResultadoRequest request)
    {
        return await _perfilAvanceAplicacion
            .ListarResultadosPerfilAvance(request);
    }

    [HttpGet]
    [Route("ListarResultadoModulosPerfilAvance")]
    public async Task<StatusResponse<IEnumerable<ResultadoModuloResponse>>>
       ListarResultadoModulosPerfilAvance(ResultadoModuloRequest request)
    {
        return await _perfilAvanceAplicacion
            .ListarResultadoModulosPerfilAvance(request);
    }
    [HttpGet]
    [Route("ListarNivelesMadurezPerfilAvance")]
    public async Task<StatusResponse<IEnumerable<NivelMadurezResponse>>>
       ListarNivelesMadurezPerfilAvance()
    {
        return await _perfilAvanceAplicacion
            .ListarNivelesMadurezPerfilAvance();
    }

    [HttpGet]
    [Route("ListarCapacitacionPerfilAvance")]
    public async Task<StatusResponse<IEnumerable<RecomendacionResponse>>> ListarCapacitacionPerfilAvance(UsuarioExtranet request)
    {
        return await _perfilAvanceAplicacion
            .ListarCapacitacionPerfilAvance(request);
    }
}
