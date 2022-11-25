using System.Data;
using Release.Helper.Data.Core;

using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Datos;

public partial class UnitOfWork : IUnitOfWork
{
    public async Task<int>
        InsertarCapacitacion(CapacitacionRequest request)
    {
        var parms = new Parameter[]
        {
             new Parameter("@id_capacitacion_resultado", request.id_capacitacion_resultado),
             new Parameter("@fecha", request.fecha),
             new Parameter("@test_aprobado", request.test_aprobado),

             new Parameter("@usuario_registro", request.usuario_registro),
             new Parameter("@fecha_registro", request.fecha_registro),
             new Parameter("@usuario_modificacion", request.usuario_modificacion),
             new Parameter("@fecha_modificacion", request.fecha_modificacion),
             new Parameter("@estado", request.estado),
        };

        var result = ExecuteScalar<int>(
            "USP_DAT_CAPACITACION_INSERTAR",
            CommandType.StoredProcedure, ref parms);

        return await Task.FromResult(result);
    }
}