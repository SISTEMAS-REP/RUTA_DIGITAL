using System.Data;
using Release.Helper.Data.Core;

using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Datos;

public partial class UnitOfWork : IUnitOfWork
{
    public async Task<IEnumerable<EvaluacionResponse>>
        ListarEvaluacion(EvaluacionRequest request)
    {
        var parms = new Parameter[]
        {
             new Parameter("@id_evaluacion", request.id_evaluacion),
             new Parameter("@id_usuario_extranet", request.id_usuario_extranet),
        };

        var result = ExecuteReader<EvaluacionResponse>(
            "USP_DAT_EVALUACION_LISTAR",
            CommandType.StoredProcedure, ref parms);

        return await Task.FromResult(result);
    }

    public async Task<int>
        InsertarEvaluacion(EvaluacionRequest request)
    {
        var parms = new Parameter[]
        {
             new Parameter("@id_usuario_extranet", request.id_usuario_extranet),
             new Parameter("@fecha_inicio", request.fecha_inicio),
             new Parameter("@fecha_fin", request.fecha_fin),
             new Parameter("@modulo_activo", request.modulo_activo),
             new Parameter("@pregunta_activa", request.pregunta_activa),
             new Parameter("@concluido", request.concluido),

             new Parameter("@usuario_registro", request.usuario_registro),
             new Parameter("@fecha_registro", request.fecha_registro),
             new Parameter("@usuario_modificacion", request.usuario_modificacion),
             new Parameter("@fecha_modificacion", request.fecha_modificacion),
             new Parameter("@estado", request.estado),
        };

        var result = ExecuteScalar<int>(
            "USP_DAT_EVALUACION_INSERTAR",
            CommandType.StoredProcedure, ref parms);

        return await Task.FromResult(result);
    }

    public async Task<int>
        ActualizarEvaluacion(EvaluacionRequest request)
    {
        var parms = new Parameter[]
        {
             new Parameter("@id_evaluacion", request.id_evaluacion),
             //new Parameter("@id_usuario_extranet", request.id_usuario_extranet),
             //new Parameter("@fecha_inicio", request.fecha_inicio),
             new Parameter("@fecha_fin", request.fecha_fin),
             new Parameter("@modulo_activo", request.modulo_activo),
             new Parameter("@pregunta_activa", request.pregunta_activa),
             new Parameter("@concluido", request.concluido),

             //new Parameter("@usuario_registro", request.usuario_registro),
             //new Parameter("@fecha_registro", request.fecha_registro),
             new Parameter("@usuario_modificacion", request.usuario_modificacion),
             new Parameter("@fecha_modificacion", request.fecha_modificacion),
             //new Parameter("@estado", request.estado),
        };

        var result = ExecuteScalar<int>(
            "USP_DAT_EVALUACION_ACTUALIZAR",
            CommandType.StoredProcedure, ref parms);

        return await Task.FromResult(result);
    }
}