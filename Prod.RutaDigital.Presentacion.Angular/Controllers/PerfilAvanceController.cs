using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prod.RutaDigital.Entidades;
using Prod.RutaDigital.Presentacion.Configuracion.Proxys;
using Prod.RutaDigital.Presentacion.Configuracion.Proxys.PerfilAvance;

namespace Prod.RutaDigital.Presentacion.Angular.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class PerfilAvanceController : ControllerBase
    {
        private readonly PerfilAvanceConsultaProxy _perfilAvanceConsultaProxy;
        public PerfilAvanceController(PerfilAvanceConsultaProxy perfilAvanceConsultaProxy)
        {
            _perfilAvanceConsultaProxy = perfilAvanceConsultaProxy;
        }

        [HttpGet("ListarCalculoPuntosUsuario")]
        public async Task<IActionResult> ListarCalculoPuntosUsuario([FromQuery] UsuarioExtranet request)
        {
            var result = await _perfilAvanceConsultaProxy
                .ListarCalculoPuntosUsuario(request);
            return Ok(result);
        }

        [HttpGet("ListarPremioConsumoUsuario")]
        public async Task<IActionResult> ListarPremioConsumoUsuario([FromQuery] UsuarioExtranet request)
        {
            var result = await _perfilAvanceConsultaProxy
                .ListarPremioConsumoUsuario(request);
            return Ok(result);
        }
    }
}
