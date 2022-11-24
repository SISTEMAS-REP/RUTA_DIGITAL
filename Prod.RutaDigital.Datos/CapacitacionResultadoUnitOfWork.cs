using System.Data;
using Release.Helper.Data.Core;

using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Datos;

public partial class UnitOfWork : IUnitOfWork
{
    public async Task<IEnumerable<CapacitacionResultadoResponse>>
        ListarCapacitacionesResultado(CapacitacionResultadoRequest request)
    {
        var parms = new Parameter[]
        {
             new Parameter("@id_capacitacion_resultado", request.id_capacitacion_resultado),
             new Parameter("@id_resultado", request.id_resultado),
             new Parameter("@id_usuario_extranet", request.id_usuario_extranet),
        };

        var result = ExecuteReader<CapacitacionResultadoResponse>(
            "USP_DAT_CAPACITACION_RESULTADO_LISTAR",
            CommandType.StoredProcedure, ref parms);

        return await Task.FromResult(result);
    }

    public async Task<int>
        InsertarCapacitacionResultado(CapacitacionResultadoRequest request)
    {
        var parms = new Parameter[]
        {
             new Parameter("@id_resultado", request.id_resultado),
             new Parameter("@id_recomendacion", request.id_recomendacion),
             new Parameter("@fecha_inicio", request.fecha_inicio),
             new Parameter("@fecha_fin", request.fecha_fin),
             new Parameter("@progreso", request.progreso),
             new Parameter("@concluido", request.concluido),
             new Parameter("@calificacion", request.calificacion),

             new Parameter("@usuario_registro", request.usuario_registro),
             new Parameter("@fecha_registro", request.fecha_registro),
             new Parameter("@usuario_modificacion", request.usuario_modificacion),
             new Parameter("@fecha_modificacion", request.fecha_modificacion),
             new Parameter("@estado", request.estado),
        };

        var result = ExecuteScalar<int>(
            "USP_DAT_CAPACITACION_RESULTADO_INSERTAR",
            CommandType.StoredProcedure, ref parms);

        return await Task.FromResult(result);
    }

    public async Task<int>
        ActualizarCapacitacionResultado(CapacitacionResultadoRequest request)
    {
        var parms = new Parameter[]
        {
             new Parameter("@id_capacitacion_resultado", request.id_capacitacion_resultado),
             //new Parameter("@id_resultado", request.id_resultado),
             //new Parameter("@id_recomendacion", request.id_recomendacion),
             //new Parameter("@fecha_inicio", request.fecha_inicio),
             new Parameter("@fecha_fin", request.fecha_fin),
             new Parameter("@progreso", request.progreso),
             new Parameter("@concluido", request.concluido),
             new Parameter("@calificacion", request.calificacion),

             //new Parameter("@usuario_registro", request.usuario_registro),
             //new Parameter("@fecha_registro", request.fecha_registro),
             new Parameter("@usuario_modificacion", request.usuario_modificacion),
             new Parameter("@fecha_modificacion", request.fecha_modificacion),
             //new Parameter("@estado", request.estado),
        };

        var result = ExecuteScalar<int>(
            "USP_DAT_CAPACITACION_RESULTADO_ACTUALIZAR",
            CommandType.StoredProcedure, ref parms);

        return await Task.FromResult(result);
    }
}