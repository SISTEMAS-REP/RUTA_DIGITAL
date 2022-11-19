using System.Data;
using Release.Helper.Data.Core;

using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Datos;

public partial class UnitOfWork : IUnitOfWork
{
    public async Task<IEnumerable<TipoTestResponse>>
        ListarTiposTest(TipoTestRequest request)
    {
        var parms = new Parameter[]
        {
             new Parameter("@id_tipo_test", request.id_tipo_test),
             new Parameter("@codigo", request.codigo),
        };

        var result = ExecuteReader<TipoTestResponse>(
            "USP_TIPO_TEST_LISTAR",
            CommandType.StoredProcedure, ref parms);

        return await Task.FromResult(result);
    }
}