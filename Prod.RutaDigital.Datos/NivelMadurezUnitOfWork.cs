using System.Data;
using Release.Helper.Data.Core;

using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Datos;

public partial class UnitOfWork : IUnitOfWork
{
    public async Task<IEnumerable<NivelMadurez>>
        ListarNivelesMadurez()
    {
        var parms = new Parameter[]
        {

        };

        var result = ExecuteReader<NivelMadurez>(
            "USP_LISTAR_NIVEL_MADUREZ",
            CommandType.StoredProcedure, ref parms);

        return await Task.FromResult(result);
    }
}
