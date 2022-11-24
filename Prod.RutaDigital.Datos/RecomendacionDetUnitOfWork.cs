using System.Data;
using Release.Helper.Data.Core;

using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Datos;

public partial class UnitOfWork : IUnitOfWork
{
    public async Task<IEnumerable<RecomendacionDetResponse>>
        ListarRecomendacionDetalles(RecomendacionDetRequest request)
    {
        var parms = new Parameter[]
        {
            new Parameter("@id_recomendacion", request.id_recomendacion)
        };

        var result = ExecuteReader<RecomendacionDetResponse>(
            "USP_DAT_RECOMENDACION_DET_LISTAR",
            CommandType.StoredProcedure, ref parms);

        return await Task.FromResult(result);
    }
}
