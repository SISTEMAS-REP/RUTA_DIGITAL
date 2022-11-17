using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    }
}
