using System.Data;
using Release.Helper.Data.Core;

using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Datos;

public partial class UnitOfWork : IUnitOfWork
{
    public async Task<IEnumerable<ResultadoModuloResponse>>
        ListarResultadoModulos(ResultadoModuloRequest request)
    {
        var parms = new Parameter[]
        {
             new Parameter("@id_resultado_modulo", request.id_resultado_modulo),
             new Parameter("@id_resultado", request.id_resultado),
             new Parameter("@id_modulo", request.id_modulo),
        };

        var result = ExecuteReader<ResultadoModuloResponse>(
            "USP_DAT_RESULTADO_MODULO_LISTAR",
            CommandType.StoredProcedure, ref parms);

        return await Task.FromResult(result);
    }

    public async Task<int>
        InsertarResultadoModulo(ResultadoModuloRequest request)
    {
        var parms = new Parameter[]
        {
             new Parameter("@id_resultado", request.id_resultado),
             new Parameter("@id_modulo", request.id_modulo),
             new Parameter("@peso_modulo", request.peso_modulo),
             new Parameter("@cant_preg", request.cant_preg),
             new Parameter("@resultado_modulo", request.resultado_modulo),
             new Parameter("@prom_result_modulo", request.prom_result_modulo),

             new Parameter("@usuario_registro", request.usuario_registro),
             new Parameter("@fecha_registro", request.fecha_registro),
             //new Parameter("@usuario_modificacion", request.usuario_modificacion),
             //new Parameter("@fecha_modificacion", request.fecha_modificacion),
             //new Parameter("@estado", request.estado),
        };

        var result = ExecuteScalar<int>(
            "USP_DAT_RESULTADO_MODULO_INSERTAR",
            CommandType.StoredProcedure, ref parms);

        return await Task.FromResult(result);
    }
}