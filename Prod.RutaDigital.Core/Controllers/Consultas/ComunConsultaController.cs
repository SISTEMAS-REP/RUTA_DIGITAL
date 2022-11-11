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

namespace Prod.RutaDigital.Core.Controllers.Consultas
{
    [ApiController]
    [Route("[controller]")]
    public class ComunConsultaController : ControllerBase
    {
        private readonly IComunAplicacion comunAplicacion;
        public ComunConsultaController(IComunAplicacion comun)
        {
            comunAplicacion = comun;
        }

        [HttpGet]
        [Route("VerificarAutoDiagnosticoHistorico")]
        public async Task<StatusResponse<LoginUnicoResponse>> VerificarAutoDiagnosticoHistorico(LoginUnicoRequest request)
        {
            return await comunAplicacion
                .VerificarAutoDiagnosticoHistorico(request);
        }

        [HttpGet]
        [Route("VerificarAutoDiagnostico")]
        public async Task<StatusResponse<LoginUnicoResponse>> VerificarAutoDiagnostico(LoginUnicoRequest request)
        {
            return await comunAplicacion
                .VerificarAutoDiagnostico(request);
        }
    }
}
