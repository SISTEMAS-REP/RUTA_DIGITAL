using Microsoft.AspNetCore.Mvc;
using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Entidades;
using Release.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod.RutaDigital.Core.Controllers.Consultas
{
    [ApiController]
    [Route("[controller]")]
    public class PremioConsultaController : ControllerBase
    {
        private readonly IPremioAplicacion premioAplicacion;
        public PremioConsultaController(IPremioAplicacion premio)
        {
            premioAplicacion = premio;
        }

        [HttpGet]
        [Route("ListarPublicidadPremio")]
        public async Task<StatusResponse<List<PremioPublicidadResponse>>> ListarPublicidadPremio()
        {
            return await premioAplicacion
                .ListarPublicidadPremio();
        }

        [HttpGet]
        [Route("ListarTipoPremio")]
        public async Task<StatusResponse<List<PremioTipoResponse>>> ListarTipoPremio()
        {
            return await premioAplicacion
                .ListarTipoPremio();
        }

        [HttpGet]
        [Route("ListarPremio")]
        public async Task<StatusResponse<List<PremioResponse>>> ListarPremio(PremioRequest request)
        {
            return await premioAplicacion
                .ListarPremio(request);
        }

        [HttpGet]
        [Route("ListarNivelPremio")]
        public async Task<StatusResponse<List<PremioNivelResponse>>> ListarNivelPremio()
        {
            return await premioAplicacion
                .ListarNivelPremio();
        }

        [HttpGet]
        [Route("ListarPuntajePremio")]
        public async Task<StatusResponse<List<PremioPuntajeResponse>>> ListarPuntajePremio()
        {
            return await premioAplicacion
                .ListarPuntajePremio();
        }
    }
}
