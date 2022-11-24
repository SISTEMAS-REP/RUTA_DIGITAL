using System.Data;
using Release.Helper.Data.Core;

using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Datos;

public partial class UnitOfWork : IUnitOfWork
{
    public async Task<IEnumerable<RecursoDetResponse>>
        ListarRecursoDetalles(RecursoDetRequest request)
    {
        var parms = new Parameter[]
        {
            new Parameter("@id_recurso", request.id_recurso)
        };

        var result = ExecuteReader<RecursoDetResponse>(
            "USP_DAT_RECURSO_DET_LISTAR",
            CommandType.StoredProcedure, ref parms);

        return await Task.FromResult(result);
    }
}
