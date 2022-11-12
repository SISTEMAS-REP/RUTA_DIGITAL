using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prod.RutaDigital.Entidades;
using Prod.RutaDigital.Presentacion.Configuracion.Proxys.AutoDiagnostico;

namespace Prod.RutaDigital.Presentacion.Angular.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]

    public class AutoDiagnosticoController : ControllerBase
    {
        private readonly AutoDiagnosticoConsultaProxy autoDiagnosticoConsulta;
        public AutoDiagnosticoController(AutoDiagnosticoConsultaProxy autoDiagnostico)
        {
            autoDiagnosticoConsulta = autoDiagnostico;
        }

        [HttpGet("VerificarAutoDiagnosticoHistorico")]
        public async Task<IActionResult> VerificarAutoDiagnosticoHistorico([FromQuery] AutoDiagnosticoRequest request)
        {
            var results = await autoDiagnosticoConsulta.VerificarAutoDiagnosticoHistorico(request);
            return Ok(results);
        }

        [HttpGet("VerificarAutoDiagnostico")]
        public async Task<IActionResult> VerificarAutoDiagnostico([FromQuery] AutoDiagnosticoRequest request)
        {
            var results = await autoDiagnosticoConsulta.VerificarAutoDiagnostico(request);
            return Ok(results);
        }
    }
}
