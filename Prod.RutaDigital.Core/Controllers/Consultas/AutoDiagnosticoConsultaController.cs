using Microsoft.AspNetCore.Mvc;
using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Datos.Interfaces;
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
    public class AutoDiagnosticoConsultaController : ControllerBase
    {
        private readonly IAutoDiagnosticoAplicacion AutoDiagnosticoAplicacion;
        public AutoDiagnosticoConsultaController(IAutoDiagnosticoAplicacion AutoDiagnostico)
        {
            AutoDiagnosticoAplicacion = AutoDiagnostico;
        }

        [HttpGet]
        [Route("VerificarAutoDiagnosticoHistorico")]
        public async Task<StatusResponse<AutoDiagnosticoResponse>> VerificarAutoDiagnosticoHistorico(AutoDiagnosticoRequest request)
        {
            return await AutoDiagnosticoAplicacion
                .VerificarAutoDiagnosticoHistorico(request);
        }

        [HttpGet]
        [Route("VerificarAutoDiagnostico")]
        public async Task<StatusResponse<AutoDiagnosticoResponse>> VerificarAutoDiagnostico(AutoDiagnosticoRequest request)
        {
            return await AutoDiagnosticoAplicacion
                .VerificarAutoDiagnostico(request);
        }
    }
}
