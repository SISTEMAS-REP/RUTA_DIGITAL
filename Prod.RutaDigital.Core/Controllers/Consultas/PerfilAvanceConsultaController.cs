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
    [Route("ListarCalculoPuntosUsuario")]
    public async Task<StatusResponse<IEnumerable<CalculoPuntosResponse>>> ListarCalculoPuntosUsuario(UsuarioExtranet request)
    {
        return await _perfilAvanceAplicacion
            .ListarCalculoPuntosUsuario(request);
    }

    [HttpGet]
    [Route("ListarPremioConsumoUsuario")]
    public async Task<StatusResponse<IEnumerable<PremioConsumoResponse>>> ListarPremioConsumoUsuario(UsuarioExtranet request)
    {
        return await _perfilAvanceAplicacion
            .ListarPremioConsumoUsuario(request);
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
}
