using Microsoft.AspNetCore.Mvc;
using Prod.RutaDigital.Core.Aplicacion;
using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Entidades;
using Release.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod.RutaDigital.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PremioComandoController : ControllerBase
    {
        private readonly IPremioAplicacion _premioAplicacion;

        public PremioComandoController(IPremioAplicacion premioAplicacion)
        {
            _premioAplicacion = premioAplicacion;
        }

        [HttpPost]
        [Route("CanjePremio")]
        public async Task<StatusResponse<PremioCanjeResponse>> CanjePremio(PremioCanjeRequest request)
        {
            return await _premioAplicacion
                .CanjePremio (request);
        }
    }
}
