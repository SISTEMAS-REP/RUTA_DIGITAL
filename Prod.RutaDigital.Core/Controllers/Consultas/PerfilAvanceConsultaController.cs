using Microsoft.AspNetCore.Mvc;
using Prod.RutaDigital.Core.Aplicacion.Interfaces;
namespace Prod.RutaDigital.Core.Controllers.Consultas
{
    [ApiController]
    [Route("[controller]")]
    public class PerfilAvanceConsultaController : ControllerBase
    {
        private readonly IPerfilAvanceAplicacion _perfilAvanceAplicacion;
        public PerfilAvanceConsultaController(IPerfilAvanceAplicacion perfilAvanceAplicacion)
        {
            _perfilAvanceAplicacion = perfilAvanceAplicacion;
        }
    }
}
