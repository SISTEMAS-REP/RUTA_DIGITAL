using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prod.RutaDigital.Entidades;
using Prod.RutaDigital.Presentacion.Configuracion.Proxys.Comun;

namespace Prod.RutaDigital.Presentacion.Angular.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("[controller]")]
    public class ComunController : ControllerBase
    {
        private readonly ComunConsultaProxy _comunConsulta;
        public ComunController(ComunConsultaProxy comunConsulta)
        {
            _comunConsulta = comunConsulta;
        }

        [AllowAnonymous]
        [HttpGet("RedireccionarLoginUnico")]
        public IActionResult RedireccionarLoginUnico([FromQuery] LoginUnico request)
        {
            var results = "";
            return Ok(results);
        }

        [AllowAnonymous]
        [HttpGet("VerificarAutoDiagnosticoHistorico")]
        public IActionResult VerificarAutoDiagnosticoHistorico([FromQuery] LoginUnicoRequest request)
        {
            var results = _comunConsulta.VerificarAutoDiagnosticoHistorico(request);
            return Ok(results);
        }

        [AllowAnonymous]
        [HttpGet("VerificarAutoDiagnostico")]
        public IActionResult VerificarAutoDiagnostico([FromQuery] LoginUnicoRequest request)
        {
            var results = _comunConsulta.VerificarAutoDiagnostico(request);
            return Ok(results);
        }
    }
}
