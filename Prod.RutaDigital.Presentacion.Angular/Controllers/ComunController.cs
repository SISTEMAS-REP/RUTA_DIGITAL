using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Presentacion.Angular.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("[controller]")]
    public class ComunController : ControllerBase
    {
        public ComunController()
        {
        }

        [AllowAnonymous]
        [HttpGet("RedireccionarLoginUnico")]
        public IActionResult RedireccionarLoginUnico([FromQuery] LoginUnico request)
        {
            var results = "";
            return Ok(results);
        }
    }
}
