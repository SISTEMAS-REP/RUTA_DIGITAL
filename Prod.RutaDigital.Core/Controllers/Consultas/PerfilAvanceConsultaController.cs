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
}
