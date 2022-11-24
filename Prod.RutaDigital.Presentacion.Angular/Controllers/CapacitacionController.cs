using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prod.LoginUnico.Presentacion.Configuracion.Extra;
using Prod.RutaDigital.Entidades;
using Prod.RutaDigital.Presentacion.Configuracion.Proxys;
using Release.Helper;

namespace Prod.RutaDigital.Presentacion.Angular.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class CapacitacionController : Controller
{
    private readonly CapacitacionResultadoConsultaProxy _capacitacionResultadoConsultaProxy;
    private readonly CurrentUserService _currentUserService;
    private readonly RecomendacionConsultaProxy _recomendacionConsultaProxy;
    private readonly RecomendacionDetConsultaProxy _recomendacionDetConsultaProxy;
    private readonly RecursoConsultaProxy _recursoConsultaProxy;
    private readonly RecursoDetConsultaProxy _recursoDetConsultaProxy;

    public CapacitacionController(CapacitacionResultadoConsultaProxy capacitacionResultadoConsultaProxy,
        CurrentUserService currentUserService,
        RecomendacionConsultaProxy recomendacionConsultaProxy,
        RecomendacionDetConsultaProxy recomendacionDetConsultaProxy,
        RecursoConsultaProxy recursoConsultaProxy,
        RecursoDetConsultaProxy recursoDetConsultaProxy)
    {
        _capacitacionResultadoConsultaProxy = capacitacionResultadoConsultaProxy;
        _currentUserService = currentUserService;
        _recomendacionConsultaProxy = recomendacionConsultaProxy;
        _recomendacionDetConsultaProxy = recomendacionDetConsultaProxy;
        _recursoConsultaProxy = recursoConsultaProxy;
        _recursoDetConsultaProxy = recursoDetConsultaProxy;
    }

    [HttpGet("ListarCapacitaciones")]
    public async Task<IActionResult>
        ListarCapacitaciones()
    {
        var response = new StatusResponse<IEnumerable<ModuloResponse>>();

        var idUsuarioExtranet = int
            .Parse(_currentUserService.User.IdUsuarioExtranet);

        var capacitacionesResultadoResponse = await _capacitacionResultadoConsultaProxy
            .ListarCapacitacionesResultado(new()
            {
                id_usuario_extranet = idUsuarioExtranet
            });

        if (capacitacionesResultadoResponse is null
           || !capacitacionesResultadoResponse.Success
           || capacitacionesResultadoResponse.Data.Count() == 0)
        {
            throw new Exception();
        }

        var capacitacionesReultado = capacitacionesResultadoResponse.Data;

        var modulos = capacitacionesReultado
            .GroupBy(g1 => new
            {
                g1.id_modulo,
                g1.orden_modulo,
                g1.nombre_modulo
            })
            .Select(s1 => new ModuloResponse()
            {
                id_modulo = s1.Key.id_modulo,
                orden = s1.Key.orden_modulo,
                nombre = s1.Key.nombre_modulo,

                niveles = s1
                .GroupBy(g2 => new
                {
                    g2.id_nivel_madurez,
                    g2.nombre_nivel_madurez
                })
                .Select(s2 => new NivelMadurezResponse()
                {
                    id_nivel_madurez = s2.Key.id_nivel_madurez,
                    nombre = s2.Key.nombre_nivel_madurez,

                    capacitaciones = s2
                    .Select(s3 => new CapacitacionResultadoResponse()
                    {
                        id_capacitacion_resultado = s3.id_capacitacion_resultado,
                        id_resultado = s3.id_resultado,

                        id_modulo = s3.id_modulo,
                        orden_modulo = s3.orden_modulo,

                        id_nivel_madurez = s3.id_nivel_madurez,
                        nombre_nivel_madurez = s3.nombre_nivel_madurez,

                        id_recomendacion = s3.id_recomendacion,
                        orden_recomendacion = s3.orden_recomendacion,
                        descripcion_recomendacion = s3.descripcion_recomendacion,
                        imagen_recomendacion = s3.imagen_recomendacion,

                        progreso = s3.progreso,
                        concluido = s3.concluido
                    })
                }),

                capacitaciones = s1.Select(s4 => new CapacitacionResultadoResponse()
                {
                    id_capacitacion_resultado = s4.id_capacitacion_resultado,
                    id_resultado = s4.id_resultado,

                    id_modulo = s4.id_modulo,
                    orden_modulo = s4.orden_modulo,

                    id_nivel_madurez = s4.id_nivel_madurez,
                    nombre_nivel_madurez = s4.nombre_nivel_madurez,

                    id_recomendacion = s4.id_recomendacion,
                    orden_recomendacion = s4.orden_recomendacion,
                    descripcion_recomendacion = s4.descripcion_recomendacion,
                    imagen_recomendacion = s4.imagen_recomendacion,

                    progreso = s4.progreso,
                    concluido = s4.concluido
                })
            });


        response.Success = true;
        response.Data = modulos;

        return Ok(response);
    }

    [HttpGet("ListarRecomendacion")]
    public async Task<IActionResult>
        ListarRecomendacion([FromQuery] RecomendacionRequest request)
    {
        var response = new StatusResponse<RecomendacionResponse>();

        var idUsuarioExtranet = int
            .Parse(_currentUserService.User.IdUsuarioExtranet);

        // Obtener recomendacion
        var recomendacionResponse = await _recomendacionConsultaProxy
            .ListarRecomendaciones(new()
            {
                id_recomendacion = request.id_recomendacion
            });

        if (recomendacionResponse is null
           || !recomendacionResponse.Success
           || recomendacionResponse.Data.Count() == 0)
        {
            throw new Exception();
        }

        var recomendacion = recomendacionResponse.Data
            .First();

        // Obtener detalle de recomendacion
        var recomendacionDetResponse = await _recomendacionDetConsultaProxy
            .ListarRecomendacionDetalles(new()
            {
                id_recomendacion = recomendacion.id_recomendacion
            });

        if (recomendacionDetResponse is null
           || !recomendacionDetResponse.Success
           || recomendacionDetResponse.Data.Count() == 0)
        {
            throw new Exception();
        }

        var recomendacionDetalles = recomendacionDetResponse.Data;

        // Obtener recursos de recomendacion
        var recursosResponse = await _recursoConsultaProxy
            .ListarRecursos(new()
            {
                id_recomendacion = recomendacion.id_recomendacion
            });

        if (recursosResponse is null
           || !recursosResponse.Success
           || recursosResponse.Data.Count() == 0)
        {
            throw new Exception();
        }

        var recursos = recursosResponse.Data;

        // Obtener detalle de los recursos

        foreach(var recurso in recursos)
        {
            var recursosDetResponse = await _recursoDetConsultaProxy
                    .ListarRecursoDetalles(new()
                    {
                        id_recurso = recurso.id_recurso
                    });

            if (recursosDetResponse is null
                || !recursosDetResponse.Success
                || recursosDetResponse.Data.Count() == 0)
            {
                throw new Exception();
            }

            var recursoDetalles = recursosDetResponse.Data;

            recurso.detalle = recursoDetalles;
        }

        /*recursos
            .ToList()
            .ForEach(async (recurso) =>
            {
                var recursosDetResponse = await _recursoDetConsultaProxy
                    .ListarRecursoDetalles(new()
                    {
                        id_recurso = recurso.id_recurso
                    });

                if (recursosDetResponse is null
                    || !recursosDetResponse.Success
                    || recursosDetResponse.Data.Count() == 0)
                {
                    throw new Exception();
                }

                var recursoDetalles = recursosDetResponse.Data;

                recurso.detalle = recursoDetalles;
            });*/

        recomendacion.detalle = recomendacionDetalles;
        recomendacion.recursos = recursos;
        
        response.Success = true;
        response.Data = recomendacion;
        return Ok(response);
    }
}
