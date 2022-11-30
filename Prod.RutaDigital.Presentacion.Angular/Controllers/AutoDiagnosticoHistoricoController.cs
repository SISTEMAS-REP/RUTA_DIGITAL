using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prod.LoginUnico.Presentacion.Configuracion.Extra;
using Prod.RutaDigital.Entidades;
using Prod.RutaDigital.Presentacion.Configuracion.Proxys;
using Release.Helper;

namespace Prod.RutaDigital.Presentacion.Angular.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AutoDiagnosticoHistoricoController : ControllerBase
    {
        private readonly CurrentUserService _currentUserService;
        private readonly EvaluacionConsultaProxy _evaluacionConsultaProxy;
        private readonly ResultadoConsultaProxy _resultadoConsultaProxy;
        private readonly ResultadoModuloConsultaProxy _resultadoModuloConsultaProxy;
        private readonly NivelMadurezConsultaProxy _nivelMadurezConsultaProxy;
        public AutoDiagnosticoHistoricoController(CurrentUserService currentUserService, 
            EvaluacionConsultaProxy evaluacionConsultaProxy,
            ResultadoConsultaProxy resultadoConsultaProxy,
            ResultadoModuloConsultaProxy resultadoModuloConsultaProxy,
            NivelMadurezConsultaProxy nivelMadurezConsultaProxy)
        {
            _currentUserService = currentUserService;
            _evaluacionConsultaProxy = evaluacionConsultaProxy;
            _resultadoConsultaProxy = resultadoConsultaProxy;
            _resultadoModuloConsultaProxy = resultadoModuloConsultaProxy;
            _nivelMadurezConsultaProxy = nivelMadurezConsultaProxy;
        }

        [HttpPost("VerificarAutodiagnosticoHistorico")]
        public async Task<IActionResult> VerificarAutodiagnosticoHistorico()
        {
            var response = new StatusResponse<EvaluacionResponse>();
            var idUsuarioExtranet = int.Parse(_currentUserService.User.IdUsuarioExtranet);

            var evaluacionHistoricoResponse = await _evaluacionConsultaProxy
                .ListarEvaluacionHistorico(new()
                {
                    id_usuario_extranet = idUsuarioExtranet
                });

            if (evaluacionHistoricoResponse is null
                || !evaluacionHistoricoResponse.Success
                || evaluacionHistoricoResponse.Data.Count() == 0)
            {
                return new ObjectResult(response);
            }

            var evaluacionHistorico = evaluacionHistoricoResponse!.Data!
                .First();

            response.Success = true;
            response.Data = new EvaluacionResponse()
            {
                concluido = evaluacionHistorico.concluido,

            };

            return Ok(response);
        }

        [HttpGet("ListarResultadoAutodiagnosticoHistorico")]
        public async Task<IActionResult>
        ListarResultadoAutodiagnosticoHistorico()
        {
            var response = new StatusResponse<ResultadoAutodiagnosticoResponse>();
            try
            {
                var fechaHoraOperacion = DateTime.Now;
                var idUsuarioExtranet = int
                    .Parse(_currentUserService.User.IdUsuarioExtranet);

                var resultadoResponse = await _resultadoConsultaProxy
                    .ListarResultadosHistorico(new()
                    {
                        id_usuario_extranet = idUsuarioExtranet
                    });

                if (resultadoResponse is null
                    || !resultadoResponse.Success
                    || resultadoResponse.Data.Count() == 0)
                {
                    throw new Exception();
                }

                var resultado = resultadoResponse.Data
                    .First();

                var resultadoModulosResponse = await _resultadoModuloConsultaProxy
                    .ListarResultadoModulosHistorico(new()
                    {
                        id_resultado = resultado.id_resultado
                    });

                if (resultadoModulosResponse is null
                    || !resultadoModulosResponse.Success
                    || resultadoModulosResponse.Data.Count() == 0)
                {
                    throw new Exception();
                }

                var resultadoModulos = resultadoModulosResponse.Data;

                // Obtener niveles de madurez
                var nivelesMadurezResponse = await _nivelMadurezConsultaProxy
                    .ListarNivelesMadurezHistorico();

                if (nivelesMadurezResponse is null
                    || !nivelesMadurezResponse.Success
                    || nivelesMadurezResponse.Data.Count() == 0)
                {
                    throw new Exception();
                }

                var nivelesMadurez = nivelesMadurezResponse.Data;

                var nivelMadurezResultado = nivelesMadurez
                    .Where(w => w.valor_min <= resultado.resultado
                            && resultado.resultado <= w.valor_max)
                    .First();

                resultado.id_nivel_madurez = nivelMadurezResultado.id_nivel_madurez;
                resultado.nombre_nivel_madurez = nivelMadurezResultado.nombre;

                nivelesMadurez
                    .ToList()
                    .ForEach(x =>
                    {
                        if (x.id_nivel_madurez == resultado.id_nivel_madurez)
                        {
                            x.seleccionado = true;
                        }
                    });

                var data = new ResultadoAutodiagnosticoResponse()
                {
                    Resultado = resultado,
                    ResultadoModulos = resultadoModulos,
                    NivelesMadurez = nivelesMadurez
                };
                response.Success = true;
                response.Data = data;
            }
            catch (Exception ex)
            {

            }
           

            
            return Ok(response);
        }
    }
}
