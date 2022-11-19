using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prod.RutaDigital.Entidades;
using Prod.RutaDigital.Presentacion.Configuracion;
using Prod.RutaDigital.Presentacion.Configuracion.Proxys;
using Release.Helper;

namespace Prod.RutaDigital.Presentacion.Angular.Controllers;

[AllowAnonymous]
[ApiController]
[Route("[controller]")]
public class TestAutodiagnosticoController : ControllerBase
{
    private static string CODIGO_TIPO_TEST = "TEST_TIPO_AUTODIAG";

    private readonly EvaluacionConsultaProxy _evaluacionConsultaProxy;
    private readonly ModuloConsultaProxy _moduloConsultaProxy;
    private readonly PreguntaConsultaProxy _preguntaConsultaProxy;
    private readonly AlternativaConsultaProxy _alternativaConsultaProxy;
    private readonly RespuestaConsultaProxy _respuestaConsultaProxy;
    private readonly TipoTestConsultaProxy _tipoTestConsultaProxy;
    private readonly AppAuditoria _appAuditoria;
    private readonly EvaluacionComandoProxy _evaluacionComandoProxy;
    private readonly RespuestaComandoProxy _respuestaComandoProxy;
    private readonly ResultadoComandoProxy _resultadoComandoProxy;
    private readonly ResultadoModuloComandoProxy _resultadoModuloComandoProxy;
    private readonly ResultadoPregComandoProxy _resultadoPregComandoProxy;
    private readonly ResultadoModuloConsultaProxy _resultadoModuloConsultaProxy;
    private readonly NivelMadurezConsultaProxy _nivelMadurezConsultaProxy;
    private readonly RecomendacionConsultaProxy _recomendacionConsultaProxy;
    private readonly CapacitacionResultadoComandoProxy _capacitacionResultadoComandoProxy;

    public TestAutodiagnosticoController(EvaluacionConsultaProxy evaluacionConsultaProxy,
        ModuloConsultaProxy moduloConsultaProxy,
        PreguntaConsultaProxy preguntaConsultaProxy,
        AlternativaConsultaProxy alternativaConsultaProxy,
        RespuestaConsultaProxy respuestaConsultaProxy,
        TipoTestConsultaProxy tipoTestConsultaProxy,
        AppAuditoria appAuditoria,
        EvaluacionComandoProxy evaluacionComandoProxy,
        RespuestaComandoProxy respuestaComandoProxy,
        ResultadoComandoProxy resultadoComandoProxy,
        ResultadoModuloComandoProxy resultadoModuloComandoProxy,
        ResultadoPregComandoProxy resultadoPregComandoProxy,
        ResultadoModuloConsultaProxy resultadoModuloConsultaProxy,
        NivelMadurezConsultaProxy nivelMadurezConsultaProxy,
        RecomendacionConsultaProxy recomendacionConsultaProxy,
        CapacitacionResultadoComandoProxy capacitacionResultadoComandoProxy)
    {
        _evaluacionConsultaProxy = evaluacionConsultaProxy;
        _moduloConsultaProxy = moduloConsultaProxy;
        _preguntaConsultaProxy = preguntaConsultaProxy;
        _alternativaConsultaProxy = alternativaConsultaProxy;
        _respuestaConsultaProxy = respuestaConsultaProxy;
        _tipoTestConsultaProxy = tipoTestConsultaProxy;
        _appAuditoria = appAuditoria;
        _evaluacionComandoProxy = evaluacionComandoProxy;
        _respuestaComandoProxy = respuestaComandoProxy;
        _resultadoComandoProxy = resultadoComandoProxy;
        _resultadoModuloComandoProxy = resultadoModuloComandoProxy;
        _resultadoPregComandoProxy = resultadoPregComandoProxy;
        _resultadoModuloConsultaProxy = resultadoModuloConsultaProxy;
        _nivelMadurezConsultaProxy = nivelMadurezConsultaProxy;
        _recomendacionConsultaProxy = recomendacionConsultaProxy;
        _capacitacionResultadoComandoProxy = capacitacionResultadoComandoProxy;
    }

    [HttpGet("ListarTestAutoDiagnostico")]
    public async Task<IActionResult>
        ListarTestAutoDiagnostico([FromQuery] EvaluacionRequest request)
    {
        var response = new StatusResponse<TestAutoDiagnosticoResponse>();

        // Obtener tipo test (autodiagnóstico)
        var tipoTestResponse = await _tipoTestConsultaProxy
            .ListarTiposTest(new()
            {
                codigo = CODIGO_TIPO_TEST
            });

        if (tipoTestResponse is null
            || !tipoTestResponse.Success
            || tipoTestResponse.Data is null)
        {
            throw new Exception();
        }

        var tipoTest = tipoTestResponse!.Data!
            .First();

        // Obtener autoevaluación del usuario
        var evaluacionResponse = await _evaluacionConsultaProxy
            .ListarEvaluacion(new()
            {
                id_usuario_extranet = request.id_usuario_extranet
            });

        // Si no tiene autoevaluación > Insertar estructura para iniciar su test
        if (evaluacionResponse is null
            || !evaluacionResponse.Success
            || evaluacionResponse.Data.Count() == 0) {

            // Obtener plantilla
            var modulosResponse = await _moduloConsultaProxy
                .ListarModulos(new());

            var preguntasResponse = await _preguntaConsultaProxy
                .ListarPreguntas(new()
                {
                    id_tipo_test = tipoTest.id_tipo_test
                });

            var alternativasResponse = await _alternativaConsultaProxy
                .ListarAlternativas(new()
                {
                    id_tipo_test = tipoTest.id_tipo_test
                });

            if (modulosResponse is null
                || !modulosResponse.Success
                || modulosResponse.Data.Count() == 0

                || preguntasResponse is null
                || !preguntasResponse.Success
                || preguntasResponse.Data.Count() == 0

                || alternativasResponse is null
                || !alternativasResponse.Success
                || alternativasResponse.Data.Count() == 0)
            {
                throw new Exception();
            }

            // Fecha y hora para auditoria
            var fechaHoraOperacion = DateTime.Now;

            // Para indicar cual es el 1er módulo y la 1ra pregunta activa
            var primerModuloActivo = modulosResponse.Data
                .First();
            var primeraPreguntaActiva = preguntasResponse.Data
                .Where(w => w.id_modulo == primerModuloActivo.id_modulo)
                .First();

            // Insertar cabecera de autodiagnóstico
            var evaluacionRequest = new EvaluacionRequest()
            {
                id_usuario_extranet = request.id_usuario_extranet,
                fecha_inicio = fechaHoraOperacion,
                modulo_activo = primerModuloActivo.id_modulo,
                pregunta_activa = primeraPreguntaActiva.id_pregunta,
                concluido = false,
                usuario_registro = _appAuditoria.Usuario,
                fecha_registro = fechaHoraOperacion,
                estado = true
            };

            var idEvaluacionResponse = await _evaluacionComandoProxy
                .InsertarEvaluacion(evaluacionRequest);

            if (idEvaluacionResponse is null
                || !idEvaluacionResponse.Success
                || idEvaluacionResponse.Data <= 0)
            {
                throw new Exception();
            }

            var idEvaluacion = idEvaluacionResponse.Data;

            // Insertar estructura de respuestas
            foreach (var modulo in modulosResponse.Data)
            {
                var preguntas = preguntasResponse.Data
                    .Where(w => w.id_modulo == modulo.id_modulo);

                foreach (var pregunta in preguntas)
                {
                    var alternativas = alternativasResponse.Data
                        .Where(w => w.id_pregunta == pregunta.id_pregunta);

                    foreach (var alternativa in alternativas)
                    {
                        var respuestaRequest = new RespuestaRequest()
                        {
                            id_evaluacion = idEvaluacion,
                            id_modulo = modulo.id_modulo,
                            id_pregunta = pregunta.id_pregunta,
                            id_alternativa = alternativa.id_alternativa,
                            peso_modulo = modulo.peso,
                            peso_alt = alternativa.peso,
                            respuesta = false,
                            usuario_registro = _appAuditoria.Usuario,
                            fecha_registro = fechaHoraOperacion,
                            estado = true
                        };

                        var idRespuestaResponse = await _respuestaComandoProxy
                            .InsertarRespuesta(respuestaRequest);

                        if (idRespuestaResponse is null
                            || !idRespuestaResponse.Success
                            || idRespuestaResponse.Data <= 0)
                        {
                            throw new Exception();
                        }
                    }
                }
            }

            // Obtener evaluación insertada
            evaluacionResponse = await _evaluacionConsultaProxy
                .ListarEvaluacion(new()
                {
                    id_evaluacion = idEvaluacion
                });

            if (evaluacionResponse is null
            || !evaluacionResponse.Success
            || evaluacionResponse.Data.Count() == 0)
            {
                throw new Exception();
            }
        }

        var evaluacion = evaluacionResponse!.Data!
            .First();

        // Verificar si la evaluación está concluida
        if (evaluacion.concluido)
        {
            response.Success = false;
            response.Messages.Add("La autoevaluación ya está concluida.");
            return Ok(response);
        }

        // Obtener respuestas del autodiagnóstico
        var respuestasResponse = await _respuestaConsultaProxy
            .ListarRespuestas(new()
            {
                id_evaluacion = evaluacion.id_evaluacion
            });

        if (respuestasResponse is null
            || !respuestasResponse.Success
            || respuestasResponse.Data.Count() == 0)
        {
            throw new Exception();
        }

        var respuestas = respuestasResponse.Data;

        // Organizar test de autodniagnóstico (estructurado)
        var test = respuestas
            .GroupBy(g1 => new
            {
                g1.id_modulo,
                g1.orden_modulo,
                g1.nombre_modulo,
                g1.descripcion_modulo,
                g1.imagen_modulo
            })
            .Select(s1 => new ModuloResponse()
            {
                id_modulo = s1.Key.id_modulo,
                orden = s1.Key.orden_modulo,
                nombre = s1.Key.nombre_modulo,
                descripcion = s1.Key.descripcion_modulo,
                imagen = s1.Key.imagen_modulo,
                preguntas = s1
                .GroupBy(g2 => new
                {
                    g2.id_pregunta,
                    g2.orden_pregunta,
                    g2.descripcion_pregunta
                })
                .Select(s2 => new PreguntaResponse()
                {
                    id_pregunta = s2.Key.id_pregunta,
                    orden = s2.Key.orden_pregunta,
                    descripcion = s2.Key.descripcion_pregunta,
                    respuestas = s2
                    .GroupBy(g3 => new
                    {
                        g3.id_respuesta,
                        g3.id_evaluacion,
                        g3.id_modulo,
                        g3.id_pregunta,

                        g3.id_alternativa,
                        g3.orden_alternativa,
                        g3.descripcion_alternativa,
                    })
                    .Select(s3 => new RespuestaResponse()
                    {
                        id_respuesta = s3.Key.id_respuesta,
                        id_evaluacion = s3.Key.id_evaluacion,
                        id_modulo = s3.Key.id_modulo,
                        id_pregunta = s3.Key.id_pregunta,

                        id_alternativa = s3.Key.id_alternativa,
                        orden_alternativa = s3.Key.orden_alternativa,
                        descripcion_alternativa = s3.Key.descripcion_alternativa,

                        respuesta = s3.First().respuesta
                    })
                })
            });

        var data = new TestAutoDiagnosticoResponse()
        {
            Evaluacion = evaluacion,
            Respuestas = respuestas,
            Test = test
        };

        response.Success = true;
        response.Data = data;
        return Ok(response);
    }

    [HttpPut("ActualizarRespuesta")]
    public async Task<IActionResult>
        ActualizarRespuesta([FromBody] RespuestaRequest request)
    {
        var fechaHoraOperacion = DateTime.Now;

        request.usuario_modificacion = _appAuditoria.Usuario;
        request.fecha_modificacion = fechaHoraOperacion;

        var respuestaResponse = await _respuestaComandoProxy
            .ActualizarRespuesta(request);

        if (respuestaResponse is null
            || !respuestaResponse.Success
            || respuestaResponse.Data <= 0)
        {
            throw new Exception();
        }

        var evaluacionRequest = new EvaluacionRequest()
        {
            id_evaluacion = request.id_evaluacion,
            id_usuario_extranet = request.id_usuario_extranet,
            modulo_activo = request.id_modulo,
            pregunta_activa = request.id_pregunta,
            usuario_modificacion = _appAuditoria.Usuario,
            fecha_modificacion = fechaHoraOperacion,
        };

        var evaluacionResponse = await _evaluacionComandoProxy
            .ActualizarEvaluacion(evaluacionRequest);

        if (evaluacionResponse is null
            || !evaluacionResponse.Success
            || evaluacionResponse.Data <= 0)
        {
            throw new Exception();
        }

        return Ok();
    }

    [HttpPost("ProcesarEvaluacion")]
    public async Task<IActionResult>
        ProcesarEvaluacion([FromBody] EvaluacionRequest request)
    {
        // Obtener tipo test (autodiagnóstico)
        var tipoTestResponse = await _tipoTestConsultaProxy
            .ListarTiposTest(new()
            {
                codigo = CODIGO_TIPO_TEST
            });

        if (tipoTestResponse is null
            || !tipoTestResponse.Success
            || tipoTestResponse.Data is null)
        {
            throw new Exception();
        }

        var tipoTest = tipoTestResponse!.Data!
            .First();

        // Obtener respuestas
        var respuestasResponse = await _respuestaConsultaProxy
            .ListarRespuestas(new()
            {
                id_evaluacion = request.id_evaluacion
            });

        if (respuestasResponse is null
            || !respuestasResponse.Success
            || respuestasResponse.Data.Count() == 0)
        {
            throw new Exception();
        }

        var respuestas = respuestasResponse.Data;

        // Organizar test de autodniagnóstico (estructurado)
        var modulos = respuestas
            .GroupBy(g1 => new
            {
                g1.id_modulo,
                //g1.orden_modulo,
                g1.peso_modulo
            })
            .Select(s1 => new ModuloResponse()
            {
                id_modulo = s1.Key.id_modulo,
                //orden = s1.Key.orden_modulo,
                peso = s1.Key.peso_modulo,
                preguntas = s1
                .GroupBy(g2 => new
                {
                    g2.id_pregunta,
                    //g2.orden_pregunta
                })
                .Select(s2 => new PreguntaResponse()
                {
                    id_pregunta = s2.Key.id_pregunta,
                    //orden = s2.Key.orden_pregunta,
                    respuestas = s2
                    .GroupBy(g3 => new
                    {
                        g3.id_respuesta,
                        //g3.id_evaluacion,
                        //g3.id_modulo,
                        //g3.id_pregunta,

                        g3.id_alternativa,
                        //g3.orden_alternativa,
                        g3.peso_alt,
                    })
                    .Select(s3 => new RespuestaResponse()
                    {
                        id_respuesta = s3.Key.id_respuesta,
                        //id_evaluacion = s3.Key.id_evaluacion,
                        //id_modulo = s3.Key.id_modulo,
                        //id_pregunta = s3.Key.id_pregunta,

                        id_alternativa = s3.Key.id_alternativa,
                        //orden_alternativa = s3.Key.orden_alternativa,
                        peso_alt = s3.Key.peso_alt,

                        respuesta = s3.First().respuesta
                    })
                })
            });

        IEnumerable<ResultadoModuloRequest> resultadoModulosRequest 
            = new List<ResultadoModuloRequest>();

        // Evaluar test de autodiagnóstico
        foreach (var modulo in modulos)
        {
            IEnumerable<ResultadoPregRequest> resultadoPregsRequest 
                = new List<ResultadoPregRequest>();

            foreach(var pregunta in modulo.preguntas)
            {
                var pesoPreg = 1.0m / pregunta.respuestas
                    .Count();

                var pesoAltSuma = pregunta.respuestas
                    .Where(w => w.respuesta == true)
                    .Sum(s => s.peso_alt);

                var promResultPreg = pesoAltSuma / pregunta.respuestas.Count();

                var resultadoPregRequest = new ResultadoPregRequest()
                {
                    id_resultado_modulo = 0,
                    id_pregunta = pregunta.id_pregunta,
                    peso_preg = pesoPreg,
                    peso_alt_suma = pesoAltSuma,
                    prom_result_preg = promResultPreg,
                };

                resultadoPregsRequest
                    .Append(resultadoPregRequest);
            }

            var cantPreg = resultadoPregsRequest
                .Count();

            var resultadoModulo = resultadoPregsRequest
                .Sum(s => s.prom_result_preg);

            var promResultModulo = modulo.peso * resultadoModulo;

            var resultadoModuloRequest = new ResultadoModuloRequest()
            {
                id_resultado = 0,
                id_modulo = modulo.id_modulo,
                peso_modulo = modulo.peso,
                cant_preg = cantPreg,
                resultado_modulo = resultadoModulo,
                prom_result_modulo = promResultModulo,

                pregs = resultadoPregsRequest,
            };

            resultadoModulosRequest
                .Append(resultadoModuloRequest);
        }

        var fechaHoraOperacion = DateTime.Now;

        var resultado = resultadoModulosRequest
            .Sum(s => s.prom_result_modulo);

        // Insertar cabecera de resultado (test de autodiagnóstico)
        var resultadoRequest = new ResultadoRequest()
        {
            id_evaluacion = request.id_evaluacion,
            id_tipo_test = tipoTest.id_tipo_test,
            id_usuario_extranet = request.id_usuario_extranet,
            resultado = resultado,

            modulos = resultadoModulosRequest,

            usuario_registro = _appAuditoria.Usuario,
            fecha_registro = fechaHoraOperacion
        };

        var idResultadoResponse = await _resultadoComandoProxy
            .InsertarResultado(resultadoRequest);

        if (idResultadoResponse is null
            || !idResultadoResponse.Success
            || idResultadoResponse.Data <= 0)
        {
            throw new Exception();
        }

        var idResultado = idResultadoResponse.Data;

        // Insertar módulos de resultado (test de autodiagnóstico)
        foreach (var moduloRequest in resultadoRequest.modulos)
        {
            moduloRequest.id_resultado = idResultado;

            moduloRequest.usuario_registro = _appAuditoria.Usuario;
            moduloRequest.fecha_registro = fechaHoraOperacion;

            var idResultadoModuloResponse = await _resultadoModuloComandoProxy
                .InsertarResultadoModulo(moduloRequest);

            if (idResultadoModuloResponse is null
                || !idResultadoModuloResponse.Success
                || idResultadoModuloResponse.Data <= 0)
            {
                throw new Exception();
            }

            var idResultadoModulo = idResultadoModuloResponse.Data;

            // Insertar preguntas de resultado (test de autodiagnóstico)
            foreach (var pregRequest in moduloRequest.pregs)
            {
                pregRequest.id_resultado_modulo = idResultadoModulo;

                pregRequest.usuario_registro = _appAuditoria.Usuario;
                pregRequest.fecha_registro = fechaHoraOperacion;

                var idResultadoPregResponse = await _resultadoPregComandoProxy
                    .InsertarResultadoPreg(pregRequest);

                if (idResultadoPregResponse is null
                    || !idResultadoPregResponse.Success
                    || idResultadoPregResponse.Data <= 0)
                {
                    throw new Exception();
                }
            }
        }

        var resultadoModulosResponse = await _resultadoModuloConsultaProxy
            .ListarResultadoModulos(new()
            {
                id_resultado = idResultado
            });

        if (resultadoModulosResponse is null
                   || !resultadoModulosResponse.Success
                   || resultadoModulosResponse.Data.Count() == 0)
        {
            throw new Exception();
        }

        var resultadoModulos = resultadoModulosResponse!.Data!;

        // Obtener niveles de madurez
        var nivelesMadurezResponse = await _nivelMadurezConsultaProxy
            .ListarNivelesMadurez();

        if (nivelesMadurezResponse is null
                   || !nivelesMadurezResponse.Success
                   || nivelesMadurezResponse.Data.Count() == 0)
        {
            throw new Exception();
        }

        var nivelesMadurez = nivelesMadurezResponse!.Data!;

        // Evaluar nivel de madures a resultado
        foreach (var resultadoModulo in resultadoModulos)
        {
            var idNivelMadurez = nivelesMadurez
                .Where(w => w.valor_min <= resultadoModulo.resultado_modulo
                    && w.valor_max >= resultadoModulo.resultado_modulo)
                .Select(s => s.id_nivel_madurez)
                .FirstOrDefault();

            if (idNivelMadurez <= 0)
            {
                throw new Exception();
            }

            // Obtener recomendacionas asociadas al nivel de madurez
            var recomendacionesResponse = await _recomendacionConsultaProxy
                .ListarRecomendaciones(new()
                {
                    id_modulo = resultadoModulo.id_modulo,
                    id_nivel_madurez = idNivelMadurez
                });

            if (recomendacionesResponse is null
                       || !recomendacionesResponse.Success
                       || recomendacionesResponse.Data.Count() == 0)
            {
                throw new Exception();
            }

            var recomendaciones = recomendacionesResponse!.Data!;

            // Recorrer para insertar recomendaciones
            foreach (var recomendacion in recomendaciones)
            {
                var capacitacionResultadoRequest = new CapacitacionResultadoRequest()
                {
                    id_resultado = idResultado,
                    id_recomendacion = recomendacion.id_recomendacion,
                    progreso = 0,

                    usuario_registro = _appAuditoria.Usuario,
                    fecha_registro = fechaHoraOperacion
                };

                var idCapacitacionResultadoResponse = await _capacitacionResultadoComandoProxy
                    .InsertarCapacitacionResultado(capacitacionResultadoRequest);

                if (idCapacitacionResultadoResponse is null
                    || !idCapacitacionResultadoResponse.Success
                    || idCapacitacionResultadoResponse.Data <= 0)
                {
                    throw new Exception();
                }

                var idCapacitacionResultado = idCapacitacionResultadoResponse.Data;
            }
        }

        return Ok();
    } 
}
