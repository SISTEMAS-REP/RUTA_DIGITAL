using System.Data;
using Release.Helper.Data.Core;

using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Datos;

public partial class UnitOfWork : IUnitOfWork
{
    public async Task<IEnumerable<NivelMadurezResponse>>
        ListarNivelesMadurez()
    {
        var parms = new Parameter[]
        {

        };

        var result = ExecuteReader<NivelMadurezResponse>(
            "USP_CAT_NIVEL_MADUREZ_LISTAR",
            CommandType.StoredProcedure, ref parms);

        return await Task.FromResult(result);
    }
}
