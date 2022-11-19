using System.Data;
using Release.Helper.Data.Core;

using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Datos;

public partial class UnitOfWork : IUnitOfWork
{
    public async Task<IEnumerable<RecomendacionResponse>>
        ListarRecomendaciones(RecomendacionRequest request)
    {
        var parms = new Parameter[]
        {
            new Parameter("@id_recomendacion", request.id_recomendacion),
            new Parameter("@id_modulo", request.id_modulo),
            new Parameter("@id_nivel_madurez", request.id_nivel_madurez),
        };

        var result = ExecuteReader<RecomendacionResponse>(
            "USP_DAT_RECOMENDACION_LISTAR",
            CommandType.StoredProcedure, ref parms);

        return await Task.FromResult(result);
    }
}
