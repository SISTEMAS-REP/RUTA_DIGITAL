using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prod.LoginUnico.Presentacion.Configuracion.Extra;
using Prod.RutaDigital.Entidades;
using Prod.RutaDigital.Presentacion.Configuracion;
using Prod.RutaDigital.Presentacion.Configuracion.Proxys;
using Prod.RutaDigital.Presentacion.Configuracion.Proxys.PerfilAvance;
using Prod.ServiciosExternos.Puertos;
using Release.Helper;

namespace Prod.RutaDigital.Presentacion.Angular.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class PerfilAvanceController : ControllerBase
    {
        private readonly PerfilAvanceConsultaProxy _perfilAvanceConsultaProxy;
        private readonly AppVariables _appVariables;
        private readonly CurrentUserService _currentUserService;
        public PerfilAvanceController(PerfilAvanceConsultaProxy perfilAvanceConsultaProxy,
            CurrentUserService currentUserService,
            AppVariables appVariables)
        {
            _perfilAvanceConsultaProxy = perfilAvanceConsultaProxy;
            _appVariables = appVariables;
            _currentUserService = currentUserService;
        }

        [HttpGet("ListarEstadisticaPerfilAvance")]
        public async Task<IActionResult> ListarEstadisticaPerfilAvance([FromQuery] UsuarioExtranet request)
        {
            var result = await _perfilAvanceConsultaProxy
                .ListarEstadisticaPerfilAvance(request);
            return Ok(result);
        }

        [HttpGet("ListarCapacitacionPerfilAvance")]
        public async Task<IActionResult> ListarCapacitacionPerfilAvance([FromQuery] UsuarioExtranet request)
        {
            var result = await _perfilAvanceConsultaProxy
                .ListarCapacitacionPerfilAvance(request);
            return Ok(result);
        }

        [HttpGet("ListarPremioConsumoPerfilAvance")]
        public async Task<IActionResult> ListarPremioConsumoPerfilAvance([FromQuery] UsuarioExtranet request)
        {
            var response = await _perfilAvanceConsultaProxy
                .ListarPremioConsumoPerfilAvance(request);

            var data = response.Data
            .Select(s =>
            {
                var fotoPath = Path.Combine(_appVariables.RutaArchivos, s.foto!);
                byte[]? numArray;

                try
                {
                    numArray = System.IO.File.ReadAllBytes(fotoPath);
                }
                catch
                {
                    numArray = null;
                }
                s.numArray = numArray;

                return s;
            });

            var result = new StatusResponse<IEnumerable<PerfilAvancePremioConsumoResponse>>()
            {
                Success = true,
                Data = data
            };

            return Ok(result);
        }

        [HttpGet("ListarResultadoPerfilAvance")]
        public async Task<IActionResult>
       ListarResultadoPerfilAvance()
        {
            var response = new StatusResponse<ResultadoAutodiagnosticoResponse>();
            var fechaHoraOperacion = DateTime.Now;
            var idUsuarioExtranet = int
                .Parse(_currentUserService.User.IdUsuarioExtranet);

            var resultadoResponse = await _perfilAvanceConsultaProxy
                .ListarResultadosPerfilAvance(new()
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

            var resultadoModulosResponse = await _perfilAvanceConsultaProxy
                .ListarResultadoModulosPerfilAvance(new()
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
            var nivelesMadurezResponse = await _perfilAvanceConsultaProxy
                .ListarNivelesMadurezPerfilAvance();

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
            return Ok(response);
        }
    }
}

