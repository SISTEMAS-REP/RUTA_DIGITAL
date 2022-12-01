using System.Data;
using Release.Helper.Data.Core;

using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Datos;

public partial class UnitOfWork : IUnitOfWork
{
    public async Task<IEnumerable<AvanceModuloResponse>>
        ListarAvancesModulos(AvanceModuloRequest request)
    {
        var parms = new Parameter[]
        {
             new Parameter("@id_avance_modulo", request.id_avance_modulo),
             new Parameter("@id_resultado", request.id_resultado),
             new Parameter("@id_modulo", request.id_modulo),
             new Parameter("@id_nivel_madurez", request.id_nivel_madurez),
        };

        var result = ExecuteReader<AvanceModuloResponse>(
            "USP_DAT_AVANCE_MODULO_LISTAR",
            CommandType.StoredProcedure, ref parms);

        return await Task.FromResult(result);
    }

    public async Task<int>
        InsertarAvanceModulo(AvanceModuloRequest request)
    {
        var parms = new Parameter[]
        {
             new Parameter("@id_resultado", request.id_resultado),
             new Parameter("@id_modulo", request.id_modulo),
             new Parameter("@id_nivel_madurez", request.id_nivel_madurez),

             new Parameter("@usuario_registro", request.usuario_registro),
             new Parameter("@fecha_registro", request.fecha_registro),
             //new Parameter("@usuario_modificacion", request.usuario_modificacion),
             //new Parameter("@fecha_modificacion", request.fecha_modificacion),
             //new Parameter("@estado", request.estado),
        };

        var result = ExecuteScalar<int>(
            "USP_DAT_AVANCE_MODULO_INSERTAR",
            CommandType.StoredProcedure, ref parms);

        return await Task.FromResult(result);
    }
}