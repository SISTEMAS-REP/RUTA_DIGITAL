using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prod.RutaDigital.Entidades;
using Prod.RutaDigital.Presentacion.Configuracion.Proxys;

namespace Prod.RutaDigital.Presentacion.Angular.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("[controller]")]

    public class PremioController : ControllerBase
    {
        private readonly PremioConsultaProxy _premioConsulta;
        public PremioController(PremioConsultaProxy premioConsulta)
        {
            _premioConsulta = premioConsulta;
        }

        [AllowAnonymous]
        [HttpGet("ListarPublicidadPremio")]
        public async Task<IActionResult> ListarPublicidadPremio()
        {
            var results = await _premioConsulta.ListarPublicidadPremio();
            return Ok(results);
        }

        [AllowAnonymous]
        [HttpGet("ListarTipoPremio")]
        public async Task<IActionResult> ListarTipoPremio()
        {
            var results = await _premioConsulta.ListarTipoPremio();
            return Ok(results);
        }

        [AllowAnonymous]
        [HttpGet("ListarPremio")]
        public async Task<IActionResult> ListarPremio()
        {
            var results = await _premioConsulta.ListarPremio();
            return Ok(results);
        }
    }
}
