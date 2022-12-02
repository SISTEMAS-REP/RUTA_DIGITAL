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
        private readonly ResultadoConsultaProxy _resultadoConsultaProxy;
        private readonly CapacitacionResultadoConsultaProxy _capacitacionResultadoConsultaProxy;
        private readonly AvanceModuloConsultaProxy _avanceModuloConsultaProxy;
        private readonly NivelMadurezConsultaProxy _nivelMadurezConsultaProxy;
        private readonly ResultadoModuloConsultaProxy _resultadoModuloConsultaProxy;

        public PerfilAvanceController(PerfilAvanceConsultaProxy perfilAvanceConsultaProxy,
            CurrentUserService currentUserService,
            AppVariables appVariables,
            ResultadoConsultaProxy resultadoConsultaProxy,
            CapacitacionResultadoConsultaProxy capacitacionResultadoConsultaProxy,
            AvanceModuloConsultaProxy avanceModuloConsultaProxy,
            NivelMadurezConsultaProxy nivelMadurezConsultaProxy,
            ResultadoModuloConsultaProxy resultadoModuloConsultaProxy)
        {
            _perfilAvanceConsultaProxy = perfilAvanceConsultaProxy;
            _appVariables = appVariables;
            _currentUserService = currentUserService;
            _resultadoConsultaProxy = resultadoConsultaProxy;
            _capacitacionResultadoConsultaProxy = capacitacionResultadoConsultaProxy;
            _avanceModuloConsultaProxy = avanceModuloConsultaProxy;
            _nivelMadurezConsultaProxy = nivelMadurezConsultaProxy;
            _resultadoModuloConsultaProxy = resultadoModuloConsultaProxy;
        }

        [HttpGet("ListarEstadisticaPerfilAvance")]
        public async Task<IActionResult> 
            ListarEstadisticaPerfilAvance([FromQuery] UsuarioExtranet request)
        {
            var result = await _perfilAvanceConsultaProxy
                .ListarEstadisticaPerfilAvance(request);
            return Ok(result);
        }

        [HttpGet("ListarCapacitacionPerfilAvance")]
        public async Task<IActionResult> 
            ListarCapacitacionPerfilAvance([FromQuery] UsuarioExtranet request)
        {
            var result = await _perfilAvanceConsultaProxy
                .ListarCapacitacionPerfilAvance(request);
            return Ok(result);
        }

        [HttpGet("ListarPremioConsumoPerfilAvance")]
        public async Task<IActionResult> 
            ListarPremioConsumoPerfilAvance([FromQuery] UsuarioExtranet request)
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

        [HttpGet("ListarResultadoPerfilAvanceV2")]
        public async Task<IActionResult>
            ListarResultadoPerfilAvanceV2()
        {
            var response = new StatusResponse<ResultadoAvanceResponse>();
            var fechaHoraOperacion = DateTime.Now;
            var idUsuarioExtranet = int
                .Parse(_currentUserService.User.IdUsuarioExtranet);

            // Obtener resultado
            var resultadoResponse = await _resultadoConsultaProxy
                .ListarResultados(new()
                {
                    id_usuario_extranet = idUsuarioExtranet
                });

            if (resultadoResponse is null
                || !resultadoResponse.Success
                || resultadoResponse.Data.Count() == 0)
            {
                throw new Exception();
            }

            // Resultado
            var resultado = resultadoResponse.Data
                .First();

            // Obtener ResultadosModulo
            var resultadosModuloResponse = await _resultadoModuloConsultaProxy
                .ListarResultadoModulos(new()
                {
                    id_resultado = resultado.id_resultado
                });

            if (resultadosModuloResponse is null
                || !resultadosModuloResponse.Success
                || resultadosModuloResponse.Data.Count() == 0)
            {
                throw new Exception();
            }

            // Resultado
            var resultadosModulo = resultadosModuloResponse.Data
                .First();

            // Obtener CapacitacionesResultado
            var capacitacionesResultadoResponse = await _capacitacionResultadoConsultaProxy
                .ListarCapacitacionesResultado(new()
                {
                    id_resultado = resultado.id_resultado,
                    id_usuario_extranet = idUsuarioExtranet
                });

            if (capacitacionesResultadoResponse is null
                || !capacitacionesResultadoResponse.Success
                || capacitacionesResultadoResponse.Data.Count() == 0)
            {
                throw new Exception();
            }

            // CapacitacionesResultado
            var capacitacionesResultado = capacitacionesResultadoResponse.Data;

            // Para hallar el porcentaje avanzado
            var nroCapacitacionesTotales = capacitacionesResultado.Count();
            var nroCapacitacionesConcluidas = capacitacionesResultado
                .Where(w => w.concluido == true)
                .Count();

            var resultadoFaltante = 1.0m - resultado.resultado;

            var resultadoAvance = resultadoFaltante 
                * nroCapacitacionesConcluidas 
                / nroCapacitacionesTotales;

            resultado.resultado += resultadoAvance;

            // Obtener AvancesModulos
            var avancesModulosResponse = await _avanceModuloConsultaProxy
                .ListarAvancesModulos(new()
                {
                    id_resultado = resultado.id_resultado,
                });

            if (avancesModulosResponse is null
                || !avancesModulosResponse.Success
                || avancesModulosResponse.Data.Count() == 0)
            {
                throw new Exception();
            }

            // AvancesModulos
            var avanceModulos = avancesModulosResponse.Data
                .GroupBy(g1 => g1.id_modulo)
                .SelectMany(s1 => s1.Where(w => w.rank_desc == 1));

            avanceModulos
                .ToList()
                .ForEach(avanceModulo =>
                {
                    var capacitacionesResultadoModulo = capacitacionesResultado
                        .Where(w => w.id_modulo == avanceModulo.id_modulo);

                    var nroCapacitacionesModuloTotales = capacitacionesResultadoModulo
                        .Count();
                    var nroCapacitacionesModuloConcluidas = capacitacionesResultadoModulo
                        .Where(w => w.concluido == true)
                        .Count();

                    var resultadoAvance = nroCapacitacionesModuloTotales 
                        / nroCapacitacionesModuloConcluidas;

                    avanceModulo.resultado = resultadoAvance;
                });

            // Obtener niveles de madurez
            var nivelesMadurezResponse = await _nivelMadurezConsultaProxy
                .ListarNivelesMadurez();

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

            var data = new ResultadoAvanceResponse()
            {
                Resultado = resultado,
                AvanceModulos = avanceModulos,
                NivelesMadurez = nivelesMadurez
            };

            response.Success = true;
            response.Data = data;
            return Ok(response);
        }
    }
}

