using System.Data;
using Release.Helper.Data.Core;

using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Datos;

public partial class UnitOfWork : IUnitOfWork
{ 
    public async Task<IEnumerable<PublicidadPie>>
        ListarPublicidadPie()
    {
        var parms = new Parameter[]
        {

        };

        var result = ExecuteReader<PublicidadPie>(
            "USP_LISTAR_PUBLICIDAD_PIE",
            CommandType.StoredProcedure, ref parms);

        return await Task.FromResult(result);
    }
}
