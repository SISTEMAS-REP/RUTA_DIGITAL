using System.Data;
using Release.Helper.Data.Core;

using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Datos;

public partial class UnitOfWork : IUnitOfWork
{
    public async Task<IEnumerable<PublicidadPremio>>
        ListarPublicidadPremio()
    {
        var parms = new Parameter[]
        {
            
        };

        var result = ExecuteReader<PublicidadPremio>(
            "USP_LISTAR_PUBLICIDAD_PREMIO",
            CommandType.StoredProcedure, ref parms);

        return await Task.FromResult(result);
    }
}
