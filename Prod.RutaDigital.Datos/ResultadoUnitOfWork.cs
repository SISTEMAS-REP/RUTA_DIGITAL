using System.Data;
using Release.Helper.Data.Core;

using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Datos;

public partial class UnitOfWork : IUnitOfWork
{
    public async Task<int>
        InsertarResultado(ResultadoRequest request)
    {
        var parms = new Parameter[]
        {
             new Parameter("@id_evaluacion", request.id_evaluacion),
             new Parameter("@id_tipo_test", request.id_tipo_test),
             new Parameter("@id_usuario_extranet", request.id_usuario_extranet),
             new Parameter("@resultado", request.resultado),

             new Parameter("@usuario_registro", request.usuario_registro),
             new Parameter("@fecha_registro", request.fecha_registro),
             new Parameter("@usuario_modificacion", request.usuario_modificacion),
             new Parameter("@fecha_modificacion", request.fecha_modificacion),
             new Parameter("@estado", request.estado),
        };

        var result = ExecuteScalar<int>(
            "USP_DAT_RESULTADO_INSERTAR",
            CommandType.StoredProcedure, ref parms);

        return await Task.FromResult(result);
    }
}