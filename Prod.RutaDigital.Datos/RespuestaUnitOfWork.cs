using System.Data;
using Release.Helper.Data.Core;

using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Datos;

public partial class UnitOfWork : IUnitOfWork
{
    public async Task<IEnumerable<RespuestaResponse>>
        ListarRespuestas(RespuestaRequest request)
    {
        var parms = new Parameter[]
        {
            new Parameter("@id_respuesta", request.id_respuesta),
            new Parameter("@id_evaluacion", request.id_evaluacion),
        };

        var result = ExecuteReader<RespuestaResponse>(
            "USP_DAT_RESPUESTA_LISTAR",
            CommandType.StoredProcedure, ref parms);

        return await Task.FromResult(result);
    }

    public async Task<int>
        InsertarRespuesta(RespuestaRequest request)
    {
        var parms = new Parameter[]
        {
             new Parameter("@id_evaluacion", request.id_evaluacion),
             new Parameter("@id_modulo", request.id_modulo),
             new Parameter("@id_pregunta", request.id_pregunta),
             new Parameter("@id_alternativa", request.id_alternativa),
             new Parameter("@peso_modulo", request.peso_modulo),
             new Parameter("@peso_alt", request.peso_alt),
             new Parameter("@respuesta", request.respuesta),

             new Parameter("@usuario_registro", request.usuario_registro),
             new Parameter("@fecha_registro", request.fecha_registro),
             new Parameter("@usuario_modificacion", request.usuario_modificacion),
             new Parameter("@fecha_modificacion", request.fecha_modificacion),
             new Parameter("@estado", request.estado),
        };

        var result = ExecuteScalar<int>(
            "USP_DAT_RESPUESTA_INSERTAR",
            CommandType.StoredProcedure, ref parms);

        return await Task.FromResult(result);
    }

    public async Task<int>
        ActualizarRespuesta(RespuestaRequest request)
    {
        var parms = new Parameter[]
        {
             new Parameter("@id_respuesta", request.id_respuesta),
             //new Parameter("@id_evaluacion", request.id_evaluacion),
             //new Parameter("@id_modulo", request.id_modulo),
             //new Parameter("@id_pregunta", request.id_pregunta),
             //new Parameter("@id_alternativa", request.id_alternativa),
             //new Parameter("@peso_modulo", request.peso_modulo),
             //new Parameter("@peso_alt", request.peso_alt),
             new Parameter("@respuesta", request.respuesta),

             //new Parameter("@usuario_registro", request.usuario_registro),
             //new Parameter("@fecha_registro", request.fecha_registro),
             new Parameter("@usuario_modificacion", request.usuario_modificacion),
             new Parameter("@fecha_modificacion", request.fecha_modificacion),
             //new Parameter("@estado", request.estado),
        };

        var result = ExecuteScalar<int>(
            "USP_DAT_RESPUESTA_ACTUALIZAR",
            CommandType.StoredProcedure, ref parms);

        return await Task.FromResult(result);
    }
}