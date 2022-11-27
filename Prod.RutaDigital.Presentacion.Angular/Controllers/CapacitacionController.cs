using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prod.LoginUnico.Presentacion.Configuracion.Extra;
using Prod.RutaDigital.Entidades;
using Prod.RutaDigital.Enumerados;
using Prod.RutaDigital.Presentacion.Configuracion;
using Prod.RutaDigital.Presentacion.Configuracion.Proxys;
using Release.Helper;
using System.Linq;

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
    private readonly ModuloConsultaProxy _moduloConsultaProxy;
    private readonly PreguntaConsultaProxy _preguntaConsultaProxy;
    private readonly AlternativaConsultaProxy _alternativaConsultaProxy;
    private readonly ResultadoConsultaProxy _resultadoConsultaProxy;
    private readonly AppAuditoria _appAuditoria;
    private readonly CapacitacionComandoProxy _capacitacionComandoProxy;
    private readonly CapacitacionDetComandoProxy _capacitacionDetComandoProxy;
    private readonly CapacitacionConsultaProxy _capacitacionConsultaProxy;

    public CapacitacionController(CapacitacionResultadoConsultaProxy capacitacionResultadoConsultaProxy,
        CurrentUserService currentUserService,
        RecomendacionConsultaProxy recomendacionConsultaProxy,
        RecomendacionDetConsultaProxy recomendacionDetConsultaProxy,
        RecursoConsultaProxy recursoConsultaProxy,
        RecursoDetConsultaProxy recursoDetConsultaProxy,
        ModuloConsultaProxy moduloConsultaProxy,
        PreguntaConsultaProxy preguntaConsultaProxy,
        AlternativaConsultaProxy alternativaConsultaProxy,
        ResultadoConsultaProxy resultadoConsultaProxy,
        AppAuditoria appAuditoria,
        CapacitacionComandoProxy capacitacionComandoProxy,
        CapacitacionDetComandoProxy capacitacionDetComandoProxy,
        CapacitacionConsultaProxy capacitacionConsultaProxy)
    {
        _capacitacionResultadoConsultaProxy = capacitacionResultadoConsultaProxy;
        _currentUserService = currentUserService;
        _recomendacionConsultaProxy = recomendacionConsultaProxy;
        _recomendacionDetConsultaProxy = recomendacionDetConsultaProxy;
        _recursoConsultaProxy = recursoConsultaProxy;
        _recursoDetConsultaProxy = recursoDetConsultaProxy;
        _moduloConsultaProxy = moduloConsultaProxy;
        _preguntaConsultaProxy = preguntaConsultaProxy;
        _alternativaConsultaProxy = alternativaConsultaProxy;
        _resultadoConsultaProxy = resultadoConsultaProxy;
        _appAuditoria = appAuditoria;
        _capacitacionComandoProxy = capacitacionComandoProxy;
        _capacitacionDetComandoProxy = capacitacionDetComandoProxy;
        _capacitacionConsultaProxy = capacitacionConsultaProxy;
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
        ListarRecomendacion([FromQuery] CapacitacionResultadoRequest request)
    {
        var response = new StatusResponse<RecomendacionResponse>();
        var idUsuarioExtranet = int
            .Parse(_currentUserService.User.IdUsuarioExtranet);

        var capacitacionResultadoResponse = await _capacitacionResultadoConsultaProxy
            .ListarCapacitacionesResultado(new()
            {
                id_capacitacion_resultado = request.id_capacitacion_resultado,
                id_usuario_extranet = idUsuarioExtranet
            });

        if (capacitacionResultadoResponse is null
           || !capacitacionResultadoResponse.Success
           || capacitacionResultadoResponse.Data.Count() == 0)
        {
            throw new Exception();
        }

        var capacitacionReultado = capacitacionResultadoResponse.Data
            .First();

        // Obtener recomendacion
        var recomendacionResponse = await _recomendacionConsultaProxy
            .ListarRecomendaciones(new()
            {
                id_recomendacion = capacitacionReultado.id_recomendacion
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

        //recomendacion.id_capacitacion_resultado = capacitacionReultado.id_capacitacion_resultado;
        recomendacion.detalle = recomendacionDetalles;
        recomendacion.recursos = recursos;
        
        response.Success = true;
        response.Data = recomendacion;
        return Ok(response);
    }

    [HttpGet("ListarTestAvance")]
    public async Task<IActionResult>
        ListarTestAvance([FromQuery] RecomendacionRequest request)
    {
        var response = new StatusResponse<TestAvanceResponse>();
        var idUsuarioExtranet = int
            .Parse(_currentUserService.User.IdUsuarioExtranet);

        var capacitacionResultadoResponse = await _capacitacionResultadoConsultaProxy
            .ListarCapacitacionesResultado(new()
            {
                id_recomendacion = request.id_recomendacion,
                id_usuario_extranet = idUsuarioExtranet
            });

        if (capacitacionResultadoResponse is null
           || !capacitacionResultadoResponse.Success
           || capacitacionResultadoResponse.Data.Count() == 0)
        {
            throw new Exception();
        }

        var capacitacionReultado = capacitacionResultadoResponse.Data
            .First();

        // Obtener recomendacion
        var recomendacionResponse = await _recomendacionConsultaProxy
            .ListarRecomendaciones(new()
            {
                id_recomendacion = capacitacionReultado.id_recomendacion
            });

        if (recomendacionResponse is null
           || !recomendacionResponse.Success
           || recomendacionResponse.Data.Count() == 0)
        {
            throw new Exception();
        }

        var recomendacion = recomendacionResponse.Data
            .First();

        // Obtener modulo
        var moduloResponse = await _moduloConsultaProxy
            .ListarModulos(new()
            {
                id_modulo = recomendacion.id_modulo
            });

        if (moduloResponse is null
            || !moduloResponse.Success
            || moduloResponse.Data.Count() == 0)
        {
            throw new Exception();
        }

        var modulo = moduloResponse.Data
            .First();

        // Obtener preguntas
        var preguntasResponse = await _preguntaConsultaProxy
            .ListarPreguntas(new()
            {
                id_tipo_test = (int)TIPO_TEST.TEST_AVANCE,
                id_modulo = modulo.id_modulo,
                id_recomendacion = recomendacion.id_recomendacion
            });

        if (preguntasResponse is null
                || !preguntasResponse.Success
                || preguntasResponse.Data.Count() == 0)
        {
            throw new Exception();
        }

        var preguntas = preguntasResponse.Data;

        // Obtener alternativas
        var alternativasResponse = await _alternativaConsultaProxy
            .ListarAlternativas(new()
            {
                id_tipo_test = (int) TIPO_TEST.TEST_AVANCE,
                id_modulo = modulo.id_modulo
            });

        if (alternativasResponse is null
                || !alternativasResponse.Success
                || alternativasResponse.Data.Count() == 0)
        {
            throw new Exception();
        }

        var alternativas = alternativasResponse.Data;

        // Organizar test de avance
        preguntas
            .ToList()
            .ForEach(pregunta =>
            {
                var preguntaAlternativas = alternativas
                    .Where(w => w.id_pregunta == pregunta.id_pregunta);

                pregunta.alternativas = preguntaAlternativas;
            });

        modulo.preguntas = preguntas;

        var data = new TestAvanceResponse()
        {
            capacitacionResultado = capacitacionReultado,
            modulo = modulo
        };

        response.Success = true;
        response.Data = data;
        return Ok(response);
    }

    [HttpPost("ValidarCapacitacionResultado")]
    public async Task<IActionResult>
        ValidarCapacitacionResultado([FromBody] CapacitacionResultadoRequest request)
    {
        var response = new StatusResponse<bool>();
        var idUsuarioExtranet = int
            .Parse(_currentUserService.User.IdUsuarioExtranet);

        var capacitacionResultadoResponse = await _capacitacionResultadoConsultaProxy
            .ListarCapacitacionesResultado(new()
            {
                id_capacitacion_resultado = request.id_capacitacion_resultado,
                id_usuario_extranet = idUsuarioExtranet
            });

        if (capacitacionResultadoResponse is null
           || !capacitacionResultadoResponse.Success
           || capacitacionResultadoResponse.Data.Count() == 0)
        {
            throw new Exception();
        }

        var capacitacionResultado = capacitacionResultadoResponse.Data
            .First();

        response.Success = true;
        response.Data = capacitacionResultado.concluido;
        return Ok(response);
    }

    [HttpPost("ValidarCapacitacionesErradas")]
    public async Task<IActionResult>
        ValidarCapacitacionesErradas([FromBody] CapacitacionRequest request)
    {
        var response = new StatusResponse<int>();
        var fechaHoraOperacion = DateTime.Now;
        var idUsuarioExtranet = int
            .Parse(_currentUserService.User.IdUsuarioExtranet);

        var capacitacionesResponse = await _capacitacionConsultaProxy
            .ListarCapacitaciones(new()
            {
                id_capacitacion_resultado = request.id_capacitacion_resultado
            });

        if (capacitacionesResponse is null
           || !capacitacionesResponse.Success)
        {
            throw new Exception();
        }

        var nroCapacitacionesErradas = capacitacionesResponse.Data
            .Where(w => w.fecha >= fechaHoraOperacion.AddHours(-1)
                && w.test_aprobado == false)
            .Count();

        response.Success = true;
        response.Data = nroCapacitacionesErradas;
        return Ok(response);
    }

    [HttpPost("ProcesarAvance")]
    public async Task<IActionResult>
        ProcesarAvance([FromBody] TestAvanceRequest request)
    {
        var response = new StatusResponse<int>();
        var fechaHoraOperacion = DateTime.Now;
        var idUsuarioExtranet = int
            .Parse(_currentUserService.User.IdUsuarioExtranet);

        var capacitacionResultadoResponse = await _capacitacionResultadoConsultaProxy
            .ListarCapacitacionesResultado(new()
            {
                id_capacitacion_resultado = request.id_capacitacion_resultado,
                id_usuario_extranet = idUsuarioExtranet,
            });

        if (capacitacionResultadoResponse is null
            || !capacitacionResultadoResponse.Success
            || capacitacionResultadoResponse.Data.Count() == 0)
        {
            throw new Exception();
        }

        var capacitacionResultado = capacitacionResultadoResponse.Data
            .First();

        var nroPreguntasCorrectas = request.respuestas
            .Where(w => w.respuesta == true)
            .GroupBy(g1 => g1.id_pregunta)
            //.Select(s1 => s1.Key)
            .Count();

        var resupuestaCapacitacion = nroPreguntasCorrectas >= 2;

        var capacitacionRequest = new CapacitacionRequest() {
            id_capacitacion_resultado = capacitacionResultado.id_capacitacion_resultado,
            fecha = fechaHoraOperacion,
            test_aprobado = resupuestaCapacitacion,

            usuario_registro = _appAuditoria.Usuario,
            fecha_registro = fechaHoraOperacion,
            estado = true
        };

        var idCapacitacionResponse = await _capacitacionComandoProxy
            .InsertarCapacitacion(capacitacionRequest);

        if (idCapacitacionResponse is null
            || !idCapacitacionResponse.Success
            || idCapacitacionResponse.Data == 0)
        {
            throw new Exception();
        }

        var idCapacitacion = idCapacitacionResponse.Data;

        foreach(var respuesta in request.respuestas)
        {
            respuesta.id_capacitacion = idCapacitacion;

            var idCapacitacionDetResponse = await _capacitacionDetComandoProxy
                .InsertarCapacitacionDet(respuesta);

            if (idCapacitacionDetResponse is null
                    || !idCapacitacionDetResponse.Success
                    || idCapacitacionDetResponse.Data == 0)
            {
                throw new Exception();
            }
        }

        var capacitacionesResponse = await _capacitacionConsultaProxy
            .ListarCapacitaciones(new()
            {
                id_capacitacion_resultado = request.id_capacitacion_resultado
            });

        if (capacitacionesResponse is null
           || !capacitacionesResponse.Success)
        {
            throw new Exception();
        }

        var nroCapacitacionesErradas = capacitacionesResponse.Data
            .Where(w => w.fecha >= fechaHoraOperacion.AddHours(-1)
                && w.test_aprobado == false)
            .Count();

        if (!resupuestaCapacitacion)
        {
            response.Success = true;
            response.Data = nroCapacitacionesErradas;
            return Ok(response);
        }

        response.Success = true;
        response.Data = 0;
        return Ok(response);
    }
}
