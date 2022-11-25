using System.Data;
using Release.Helper.Data.Core;

using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Datos;

public partial class UnitOfWork : IUnitOfWork
{
    public async Task<IEnumerable<ModuloResponse>>
        ListarModulos(ModuloRequest request)
    {
        var parms = new Parameter[]
        {
             new Parameter("@id_modulo", request.id_modulo),
        };

        var result = ExecuteReader<ModuloResponse>(
            "USP_DAT_MODULO_LISTAR",
            CommandType.StoredProcedure, ref parms);

        return await Task.FromResult(result);
    }
}