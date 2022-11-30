using System.Data;
using Release.Helper.Data.Core;

using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Datos;

public partial class UnitOfWork : IUnitOfWork
{
    public async Task<int>
        InsertarResultadoPreg(ResultadoPregRequest request)
    {
        var parms = new Parameter[]
        {
             new Parameter("@id_resultado_modulo", request.id_resultado_modulo),
             new Parameter("@id_pregunta", request.id_pregunta),
             new Parameter("@peso_preg", request.peso_preg),
             new Parameter("@peso_alt_suma", request.peso_alt_suma),
             new Parameter("@prom_result_preg", request.prom_result_preg),

             new Parameter("@usuario_registro", request.usuario_registro),
             new Parameter("@fecha_registro", request.fecha_registro),
             //new Parameter("@usuario_modificacion", request.usuario_modificacion),
             //new Parameter("@fecha_modificacion", request.fecha_modificacion),
             //new Parameter("@estado", request.estado),
        };

        var result = ExecuteScalar<int>(
            "USP_DAT_RESULTADO_PREG_INSERTAR",
            CommandType.StoredProcedure, ref parms);

        return await Task.FromResult(result);
    }
}