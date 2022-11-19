using System.Data;
using Release.Helper.Data.Core;

using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Datos;

public partial class UnitOfWork : IUnitOfWork
{
    public async Task<IEnumerable<AlternativaResponse>>
        ListarAlternativas(AlternativaRequest request)
    {
        var parms = new Parameter[]
        {
             new Parameter("@id_tipo_test", request.id_tipo_test),
        };

        var result = ExecuteReader<AlternativaResponse>(
            "USP_DAT_ALTERNATIVA_LISTAR",
            CommandType.StoredProcedure, ref parms);

        return await Task.FromResult(result);
    }
}