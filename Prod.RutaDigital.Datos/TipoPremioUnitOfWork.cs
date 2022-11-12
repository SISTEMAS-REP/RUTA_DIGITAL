using System.Data;
using Release.Helper.Data.Core;

using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Datos;

public partial class UnitOfWork : IUnitOfWork
{
    public async Task<IEnumerable<TipoPremio>>
        ListarTiposPremio()
    {
        var parms = new Parameter[]
        {

        };

        var result = ExecuteReader<TipoPremio>(
            "USP_LISTAR_TIPO_PREMIO",
            CommandType.StoredProcedure, ref parms);

        return await Task.FromResult(result);
    }

}
