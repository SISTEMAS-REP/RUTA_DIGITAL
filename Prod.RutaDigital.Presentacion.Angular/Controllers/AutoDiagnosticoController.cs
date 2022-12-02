using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prod.LoginUnico.Presentacion.Configuracion.Extra;
using Prod.RutaDigital.Entidades;
using Prod.RutaDigital.Enumerados;
using Prod.RutaDigital.Presentacion.Configuracion;
using Prod.RutaDigital.Presentacion.Configuracion.Proxys;
using Release.Helper;

namespace Prod.RutaDigital.Presentacion.Angular.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class AutodiagnosticoController : ControllerBase
{
    private readonly CurrentUserService _currentUserService;
    private readonly EvaluacionConsultaProxy _evaluacionConsultaProxy;
    private readonly ModuloConsultaProxy _moduloConsultaProxy;
    private readonly PreguntaConsultaProxy _preguntaConsultaProxy;
    private readonly AlternativaConsultaProxy _alternativaConsultaProxy;
    private readonly RespuestaConsultaProxy _respuestaConsultaProxy;
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
    private readonly ResultadoConsultaProxy _resultadoConsultaProxy;
    private readonly CapacitacionResultadoConsultaProxy _capacitacionResultadoConsultaProxy;
    private readonly AvanceModuloComandoProxy _avanceModuloComandoProxy;

    public AutodiagnosticoController(CurrentUserService currentUserService,
        EvaluacionConsultaProxy evaluacionConsultaProxy,
        ModuloConsultaProxy moduloConsultaProxy,
        PreguntaConsultaProxy preguntaConsultaProxy,
        AlternativaConsultaProxy alternativaConsultaProxy,
        RespuestaConsultaProxy respuestaConsultaProxy,
        AppAuditoria appAuditoria,
        EvaluacionComandoProxy evaluacionComandoProxy,
        RespuestaComandoProxy respuestaComandoProxy,
        ResultadoComandoProxy resultadoComandoProxy,
        ResultadoModuloComandoProxy resultadoModuloComandoProxy,
        ResultadoPregComandoProxy resultadoPregComandoProxy,
        ResultadoModuloConsultaProxy resultadoModuloConsultaProxy,
        NivelMadurezConsultaProxy nivelMadurezConsultaProxy,
        RecomendacionConsultaProxy recomendacionConsultaProxy,
        CapacitacionResultadoComandoProxy capacitacionResultadoComandoProxy,
        ResultadoConsultaProxy resultadoConsultaProxy,
        CapacitacionResultadoConsultaProxy capacitacionResultadoConsultaProxy,
        AvanceModuloComandoProxy avanceModuloComandoProxy)
    {
        _currentUserService = currentUserService;
        _evaluacionConsultaProxy = evaluacionConsultaProxy;
        _moduloConsultaProxy = moduloConsultaProxy;
        _preguntaConsultaProxy = preguntaConsultaProxy;
        _alternativaConsultaProxy = alternativaConsultaProxy;
        _respuestaConsultaProxy = respuestaConsultaProxy;
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
        _resultadoConsultaProxy = resultadoConsultaProxy;
        _capacitacionResultadoConsultaProxy = capacitacionResultadoConsultaProxy;
        _avanceModuloComandoProxy = avanceModuloComandoProxy;
    }

    [HttpPost("VerificarAutodiagnostico")]
    public async Task<IActionResult>
        VerificarAutodiagnostico()
    {
        var response = new StatusResponse<EvaluacionResponse>();
        var idUsuarioExtranet = int
            .Parse(_currentUserService.User.IdUsuarioExtranet);

        // Obtener autoevaluación del usuario
        var evaluacionResponse = await _evaluacionConsultaProxy
            .ListarEvaluacion(new()
            {
                id_usuario_extranet = idUsuarioExtranet
            });

        if (evaluacionResponse is null
            || !evaluacionResponse.Success
            || evaluacionResponse.Data.Count() == 0)
        {
            //response.StatusCode = StatusCodes.Status404NotFound;
            return new ObjectResult(response);
        }

        var evaluacion = evaluacionResponse!.Data!
            .First();

        response.Success = true;
        response.Data = new EvaluacionResponse()
        {
            concluido = evaluacion.concluido,

        };

        return Ok(response);
    }

    [HttpGet("ListarTestAutodiagnostico")]
    public async Task<IActionResult>
        ListarTestAutodiagnostico()
    {
        var response = new StatusResponse<TestAutodiagnosticoResponse>();
        var fechaHoraOperacion = DateTime.Now;
        var idUsuarioExtranet = int
            .Parse(_currentUserService.User.IdUsuarioExtranet);

        // Obtener autoevaluación del usuario
        var evaluacionResponse = await _evaluacionConsultaProxy
            .ListarEvaluacion(new()
            {
                id_usuario_extranet = idUsuarioExtranet
            });

        // Si no tiene autoevaluación
        // Insertar estructura para iniciar su test
        if (evaluacionResponse is null
            || !evaluacionResponse.Success
            || evaluacionResponse.Data.Count() == 0)
        {

            // Obtener plantilla
            var modulosResponse = await _moduloConsultaProxy
                .ListarModulos(new());

            var preguntasResponse = await _preguntaConsultaProxy
                .ListarPreguntas(new()
                {
                    id_tipo_test = (int)TIPO_TEST.TEST_AUTODIAGNOSTICO
                });

            var alternativasResponse = await _alternativaConsultaProxy
                .ListarAlternativas(new()
                {
                    id_tipo_test = (int)TIPO_TEST.TEST_AUTODIAGNOSTICO
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

            // Para indicar cual es el 1er módulo y la 1ra pregunta activa
            var primerModuloActivo = modulosResponse.Data
                .First();
            var primeraPreguntaActiva = preguntasResponse.Data
                .Where(w => w.id_modulo == primerModuloActivo.id_modulo)
                .First();

            // Insertar cabecera de autodiagnóstico
            var evaluacionRequest = new EvaluacionRequest()
            {
                id_usuario_extranet = idUsuarioExtranet,
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
                            peso_modulo = modulo.peso ?? 0,
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
                id_evaluacion = evaluacion.id_evaluacion,
                //id_tipo_test = (int) TIPO_TEST.TEST_AUTODIAGNOSTICO
            });

        if (respuestasResponse is null
            || !respuestasResponse.Success
            || respuestasResponse.Data.Count() == 0)
        {
            throw new Exception();
        }

        var respuestas = respuestasResponse.Data;

        // Organizar test de autodiagnóstico (estructurado)
        var modulos = respuestas
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
                    g2.descripcion_pregunta,
                    g2.id_tipo_respuesta
                })
                .Select(s2 => new PreguntaResponse()
                {
                    id_pregunta = s2.Key.id_pregunta,
                    id_tipo_respuesta = s2.Key.id_tipo_respuesta,
                    orden = s2.Key.orden_pregunta,
                    descripcion = s2.Key.descripcion_pregunta,
                    respuestas = s2
                    .Select(s3 => new RespuestaResponse()
                    {
                        id_respuesta = s3.id_respuesta,
                        id_evaluacion = s3.id_evaluacion,
                        id_modulo = s3.id_modulo,
                        id_pregunta = s3.id_pregunta,

                        id_alternativa = s3.id_alternativa,
                        orden_alternativa = s3.orden_alternativa,
                        descripcion_alternativa = s3.descripcion_alternativa,

                        respuesta = s3.respuesta
                    })
                })
            });

        var data = new TestAutodiagnosticoResponse()
        {
            Evaluacion = evaluacion,
            //Respuestas = respuestas,
            Modulos = modulos
        };

        response.Success = true;
        response.Data = data;
        return Ok(response);
    }

    [HttpPut("ActualizarRespuesta")]
    public async Task<IActionResult>
        ActualizarRespuesta([FromBody] RespuestaRequest request)
    {
        var response = new StatusResponse<IEnumerable<RespuestaResponse>>();
        var fechaHoraOperacion = DateTime.Now;
        var idUsuarioExtranet = int
            .Parse(_currentUserService.User.IdUsuarioExtranet);

        // Buscar respuesta
        var respuestaResponse = await _respuestaConsultaProxy
            .ListarRespuestas(new()
            {
                id_respuesta = request.id_respuesta,
                //id_tipo_test = (int) TIPO_TEST.TEST_AUTODIAGNOSTICO,
            });

        if (respuestaResponse is null
            || !respuestaResponse.Success
            || respuestaResponse.Data.Count() == 0)
        {
            throw new Exception();
        }

        // Respuesta
        var respuesta = respuestaResponse.Data
            .First();

        // Buscar evaluación
        var evaluacionResponse = await _evaluacionConsultaProxy
            .ListarEvaluacion(new()
            {
                id_evaluacion = respuesta.id_evaluacion,
                id_usuario_extranet = idUsuarioExtranet,
            });

        if (evaluacionResponse is null
            || !evaluacionResponse.Success
            || evaluacionResponse.Data.Count() == 0)
        {
            throw new Exception();
        }

        // Evaluacion
        var evaluacion = evaluacionResponse.Data
            .First();

        // Buscar respuestas
        var respuestasResponse = await _respuestaConsultaProxy
            .ListarRespuestas(new()
            {
                id_evaluacion = evaluacion.id_evaluacion,
                id_modulo = respuesta.id_modulo,
                id_pregunta = respuesta.id_pregunta,
                id_tipo_test = (int)TIPO_TEST.TEST_AUTODIAGNOSTICO,
            });

        if (respuestasResponse is null
            || !respuestasResponse.Success
            || respuestasResponse.Data.Count() == 0)
        {
            throw new Exception();
        }

        var respuestas = respuestasResponse.Data;

        var preguntaResponse = await _preguntaConsultaProxy
            .ListarPreguntas(new()
            {
                id_pregunta = respuesta.id_pregunta
            });

        if (preguntaResponse is null
            || !preguntaResponse.Success
            || preguntaResponse.Data.Count() == 0)
        {
            throw new Exception();
        }

        var pregunta = preguntaResponse.Data
            .First();

        // Tipo de pregunta
        var idTipoRespuesta = pregunta.id_tipo_respuesta;

        // Si el tipo de pregunta es única
        if (idTipoRespuesta == (int)TIPO_RESPUESTA.UNICA)
        {
            // Obtener una pregunta respondida
            var respondida = respuestasResponse.Data
                .Where(w => w.respuesta == true
                    && w.id_respuesta != request.id_respuesta)
                .FirstOrDefault();

            // Si existe y es diferente a la que se requiere actualizar
            if (respondida is not null
                && respuesta.id_respuesta != respondida.id_respuesta)
            {
                var actualizarOtraRespuestaRequest = new RespuestaRequest()
                {
                    id_respuesta = respondida.id_respuesta,
                    respuesta = false,
                    usuario_modificacion = _appAuditoria.Usuario,
                    fecha_modificacion = fechaHoraOperacion
                };

                // Actualizar respuesta con estado de respuesta = false
                var actualizarOtraRespuestaResponse = await _respuestaComandoProxy
                    .ActualizarRespuesta(actualizarOtraRespuestaRequest);

                if (actualizarOtraRespuestaResponse is null
                    || !actualizarOtraRespuestaResponse.Success
                    || actualizarOtraRespuestaResponse.Data <= 0)
                {
                    throw new Exception();
                }

                var idOtraRespuesta = actualizarOtraRespuestaResponse.Data;

                respuestas
                    .ToList()
                    .ForEach(x =>
                    {
                        if (x.id_respuesta == idOtraRespuesta)
                        {
                            x.respuesta = false;
                        }
                    });
                /*.Where(w => w.id_respuesta == idOtraRespuesta)
                .Select(s => { 
                    s.respuesta = false; 
                    return s; 
                });*/
            }
        }

        var actualizarRespuestaRequest = new RespuestaRequest()
        {
            id_respuesta = respuesta.id_respuesta,
            respuesta = !respuesta.respuesta,
            usuario_modificacion = _appAuditoria.Usuario,
            fecha_modificacion = fechaHoraOperacion
        };

        // Actualizar respuesta
        var actualizarRespuestaResponse = await _respuestaComandoProxy
            .ActualizarRespuesta(actualizarRespuestaRequest);

        if (actualizarRespuestaResponse is null
            || !actualizarRespuestaResponse.Success
            || actualizarRespuestaResponse.Data <= 0)
        {
            throw new Exception();
        }

        var evaluacionRequest = new EvaluacionRequest()
        {
            id_evaluacion = evaluacion.id_evaluacion,
            modulo_activo = respuesta.id_modulo,
            pregunta_activa = respuesta.id_pregunta,
            usuario_modificacion = _appAuditoria.Usuario,
            fecha_modificacion = fechaHoraOperacion,
        };

        var actualizarEvaluacionResponse = await _evaluacionComandoProxy
            .ActualizarEvaluacion(evaluacionRequest);

        if (actualizarEvaluacionResponse is null
            || !actualizarEvaluacionResponse.Success
            || actualizarEvaluacionResponse.Data <= 0)
        {
            throw new Exception();
        }

        respuestas
            .ToList()
            .ForEach(x =>
            {
                if (x.id_respuesta == request.id_respuesta)
                {
                    x.respuesta = !respuesta.respuesta;
                }
            });/*
            .Where(w => w.id_respuesta == respuesta.id_respuesta)
            .Select(s => { 
                s.respuesta = !respuesta.respuesta; 
                return s; 
            });*/

        response.Success = true;
        response.Data = respuestas;
        return Ok(response);
    }

    [HttpPost("ValidarModulo")]
    public async Task<IActionResult>
        ValidarModulo([FromBody] ModuloRequest request)
    {
        var response = new StatusResponse<bool>();
        var idUsuarioExtranet = int
            .Parse(_currentUserService.User.IdUsuarioExtranet);

        var evaluacionResponse = await _evaluacionConsultaProxy
            .ListarEvaluacion(new()
            {
                id_usuario_extranet = idUsuarioExtranet
            });

        if (evaluacionResponse is null
            || !evaluacionResponse.Success
            || evaluacionResponse.Data.Count() == 0)
        {
            throw new Exception();
        }

        // Evaluacion
        var evaluacion = evaluacionResponse.Data
            .First();

        var respuestasResponse = await _respuestaConsultaProxy
            .ListarRespuestas(new()
            {
                id_evaluacion = evaluacion.id_evaluacion,
                id_modulo = request.id_modulo,
                //id_tipo_test = (int) TIPO_TEST.TEST_AUTODIAGNOSTICO
            });

        if (respuestasResponse is null
            || !respuestasResponse.Success
            || respuestasResponse.Data.Count() == 0)
        {
            throw new Exception();
        }

        var respuestas = respuestasResponse.Data;

        var preguntasTotal = respuestas
            .GroupBy(g1 => g1.id_pregunta)
            .Select(s1 => new PreguntaResponse()
            {
                id_pregunta = s1.Key,
                respuestas = s1.Select(s2 => new RespuestaResponse()
                {
                    id_respuesta = s2.id_respuesta,
                    respuesta = s2.respuesta
                })
            });

        var preguntasConRespuesta = preguntasTotal
            .Where(w1 => w1.respuestas
                .Where(w1 => w1.respuesta == true)
                .Count() > 0);

        var result = preguntasTotal.Count() == preguntasConRespuesta.Count();

        response.Success = true;
        response.Data = result;
        return Ok(response);
    }

    [HttpPost("ProcesarEvaluacion")]
    public async Task<IActionResult>
        ProcesarEvaluacion()
    {
        var response = new StatusResponse<bool>();
        var fechaHoraOperacion = DateTime.Now;
        var idUsuarioExtranet = int
            .Parse(_currentUserService.User.IdUsuarioExtranet);

        // Obtener evaluación
        var evaluacionResponse = await _evaluacionConsultaProxy
            .ListarEvaluacion(new()
            {
                id_usuario_extranet = idUsuarioExtranet
            });

        if (evaluacionResponse is null
            || !evaluacionResponse.Success
            || evaluacionResponse.Data.Count() == 0)
        {
            throw new Exception();
        }

        // Evaluacion
        var evaluacion = evaluacionResponse.Data
            .First();

        // Si no está concluido
        if (!evaluacion.concluido)
        {
            var idEvaluacionResponse = await _evaluacionComandoProxy
                .ActualizarEvaluacion(new()
                {
                    id_evaluacion = evaluacion.id_evaluacion,
                    fecha_fin = fechaHoraOperacion,
                    modulo_activo = evaluacion.modulo_activo,
                    pregunta_activa = evaluacion.pregunta_activa,
                    concluido = true,

                    usuario_modificacion = _appAuditoria.Usuario,
                    fecha_modificacion = fechaHoraOperacion
                });

            if (idEvaluacionResponse is null
                || !idEvaluacionResponse.Success
                || idEvaluacionResponse.Data <= 0)
            {
                throw new Exception();
            }
        }

        // Obtener Resultado
        var resultadoResponse = await _resultadoConsultaProxy
            .ListarResultados(new()
            {
                id_evaluacion = evaluacion.id_evaluacion,
                id_usuario_extranet = idUsuarioExtranet
            });

        if (resultadoResponse is null
            || !resultadoResponse.Success)
        {
            throw new Exception();
        }

        // id de Resultado
        var idResultado = resultadoResponse.Data?
            .FirstOrDefault()?.id_resultado ?? 0;

        // Si no hay resultado registrado
        if (idResultado <= 0)
        {
            // Obtener respuestas
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

            // Respuestas
            var respuestas = respuestasResponse.Data;

            // Organizar test de autodniagnóstico (estructurado)
            var modulos = respuestas
                .GroupBy(g1 => new
                {
                    g1.id_modulo,
                    g1.peso_modulo
                })
                .Select(s1 => new ModuloResponse()
                {
                    id_modulo = s1.Key.id_modulo,
                    peso = s1.Key.peso_modulo,
                    preguntas = s1
                    .GroupBy(g2 => new
                    {
                        g2.id_pregunta,
                    })
                    .Select(s2 => new PreguntaResponse()
                    {
                        id_pregunta = s2.Key.id_pregunta,
                        respuestas = s2.Select(s3 => new RespuestaResponse()
                        {
                            id_respuesta = s3.id_respuesta,
                            id_alternativa = s3.id_alternativa,
                            peso_alt = s3.peso_alt,
                            respuesta = s3.respuesta
                        })
                    })
                });

            // Evaluar test de autodiagnóstico
            var resultadoModulosRequest = modulos
                .Select(modulo =>
                {
                    var nroPreguntasModulo = modulo.preguntas!
                        .Count();

                    var resultadoPregsRequest = modulo.preguntas!
                    .Select(pregunta =>
                    {
                        var pesoPreg = 1.0m
                            / nroPreguntasModulo;

                        var pesoAltSuma = pregunta.respuestas
                            .Where(w => w.respuesta == true)
                            .Sum(s => s.peso_alt);

                        pesoAltSuma = pesoAltSuma < 1.0m
                        ? pesoAltSuma
                        : 1.0m;

                        var promResultPreg = pesoPreg * pesoAltSuma;

                        return new ResultadoPregRequest()
                        {
                            id_resultado_modulo = 0,
                            id_pregunta = pregunta.id_pregunta,
                            peso_preg = pesoPreg,
                            peso_alt_suma = pesoAltSuma,
                            prom_result_preg = promResultPreg,
                        };
                    });

                    var resultadoModulo = resultadoPregsRequest
                        .Sum(s => s.prom_result_preg);

                    var promResultModulo = modulo.peso * resultadoModulo;

                    return new ResultadoModuloRequest()
                    {
                        id_resultado = 0,
                        id_modulo = modulo.id_modulo,
                        peso_modulo = modulo.peso ?? 0,
                        cant_preg = nroPreguntasModulo,
                        resultado_modulo = resultadoModulo,
                        prom_result_modulo = promResultModulo ?? 0,

                        pregs = resultadoPregsRequest,
                    };
                });

            // Resultado de todo el test
            var resultado = resultadoModulosRequest
                .Sum(s => s.prom_result_modulo);

            // Insertar cabecera de resultado (test de autodiagnóstico)
            var resultadoRequest = new ResultadoRequest()
            {
                id_evaluacion = evaluacion.id_evaluacion,
                id_tipo_test = (int)TIPO_TEST.TEST_AUTODIAGNOSTICO,
                id_usuario_extranet = idUsuarioExtranet,
                resultado = resultado,

                modulos = resultadoModulosRequest,

                usuario_registro = _appAuditoria.Usuario,
                fecha_registro = fechaHoraOperacion,
                estado = true
            };

            var idResultadoResponse = await _resultadoComandoProxy
                .InsertarResultado(resultadoRequest);

            if (idResultadoResponse is null
                || !idResultadoResponse.Success
                || idResultadoResponse.Data <= 0)
            {
                throw new Exception();
            }

            // id de Resultado insertado
            idResultado = idResultadoResponse.Data;

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

                // id de ResultadoModulo insertado
                var idResultadoModulo = idResultadoModuloResponse.Data;

                // Insertar preguntas de resultado (test de autodiagnóstico)
                foreach (var pregRequest in moduloRequest!.pregs!)
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
        }

        // Obtener CapacitacionesResultado
        var capacitacionesResultadoResponse = await _capacitacionResultadoConsultaProxy
            .ListarCapacitacionesResultado(new()
            {
                id_resultado = idResultado,
                id_usuario_extranet = idUsuarioExtranet
            });

        if (capacitacionesResultadoResponse is null
            || !capacitacionesResultadoResponse.Success)
        {
            throw new Exception();
        }

        // CapacitacionesResultado
        var capacitacionesResultado = capacitacionesResultadoResponse.Data;

        // Si no hay CapacitacionesResultado
        if (capacitacionesResultado is null
            || capacitacionesResultado.Count() == 0)
        {
            // Listar ResultadoModulos
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

            // ResultadoModulos
            var resultadoModulos = resultadoModulosResponse.Data;

            // Obtener NivelesMadurez
            var nivelesMadurezResponse = await _nivelMadurezConsultaProxy
                .ListarNivelesMadurez();

            if (nivelesMadurezResponse is null
                || !nivelesMadurezResponse.Success
                || nivelesMadurezResponse.Data.Count() == 0)
            {
                throw new Exception();
            }

            // NivelesMadurez
            var nivelesMadurez = nivelesMadurezResponse.Data;

            // Evaluar nivel de madurez a resultado
            foreach (var resultadoModulo in resultadoModulos)
            {
                // No considerar el nivel de madurez EXPERTO (5)
                var resultadoNivelesMadurez = nivelesMadurez
                    .Where(w => w.valor_max >= resultadoModulo.resultado_modulo);

                /*// Primer nivel de madurez
                var resultadoNivelMadurez = resultadoNivelesMadurez
                    .FirstOrDefault();

                if (resultadoNivelMadurez is null)
                {
                    throw new Exception();
                }*/

                // Insertar Nivel de Madurez en Avance
                var idAvanceModulo = await _avanceModuloComandoProxy
                    .InsertarAvanceModulo(new()
                    {
                        id_resultado = idResultado,
                        id_modulo = resultadoModulo.id_modulo,
                        id_nivel_madurez = resultadoModulo.id_nivel_madurez,

                        usuario_registro = _appAuditoria.Usuario,
                        fecha_registro = fechaHoraOperacion
                    });

                if (idAvanceModulo is null
                    || !idAvanceModulo.Success
                    || idAvanceModulo.Data <= 0)
                {
                    throw new Exception();
                }

                // Si el primer nivel de madurez es diferente a EXPERTO
                var codigoNivelExperto = (int)NIVEL_MADUREZ.EXPERTO;
                if (!resultadoModulo.codigo_nivel_madurez!
                    .Equals(codigoNivelExperto.ToString()))
                {
                    // Recorrer los niveles de madurez
                    foreach (var resultadoNivel in resultadoNivelesMadurez)
                    {
                        // Obtener recomendacionas asociadas al nivel de madurez
                        var recomendacionesResponse = await _recomendacionConsultaProxy
                            .ListarRecomendaciones(new()
                            {
                                id_modulo = resultadoModulo.id_modulo,
                                id_nivel_madurez = resultadoNivel.id_nivel_madurez
                            });

                        if (recomendacionesResponse is null
                            || !recomendacionesResponse.Success)
                        {
                            throw new Exception();
                        }

                        var recomendaciones = recomendacionesResponse.Data;

                        // Recorrer para insertar recomendaciones
                        foreach (var recomendacion in recomendaciones)
                        {
                            var capacitacionResultadoRequest = new CapacitacionResultadoRequest()
                            {
                                id_resultado = idResultado,
                                id_modulo = resultadoModulo.id_modulo,
                                id_recomendacion = recomendacion.id_recomendacion,
                                progreso = 0,
                                concluido = false,
                                calificacion = 0,

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
                }


            }
        }

        response.Success = true;
        response.Data = true;
        return Ok(response);
    }

    [HttpGet("ListarResultadoAutodiagnostico")]
    public async Task<IActionResult>
        ListarResultadoAutodiagnostico()
    {
        var response = new StatusResponse<ResultadoAutodiagnosticoResponse>();
        var fechaHoraOperacion = DateTime.Now;
        var idUsuarioExtranet = int
            .Parse(_currentUserService.User.IdUsuarioExtranet);

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

        var resultado = resultadoResponse.Data
            .First();

        var resultadoModulosResponse = await _resultadoModuloConsultaProxy
            .ListarResultadoModulos(new()
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
