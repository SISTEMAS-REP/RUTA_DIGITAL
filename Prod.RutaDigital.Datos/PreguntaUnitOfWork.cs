using System.Data;
using Release.Helper.Data.Core;

using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Datos;

public partial class UnitOfWork : IUnitOfWork
{
    public async Task<IEnumerable<PreguntaResponse>>
        ListarPreguntas(PreguntaRequest request)
    {
        var parms = new Parameter[]
        {
             new Parameter("@id_pregunta", request.id_pregunta),
             new Parameter("@id_tipo_test", request.id_tipo_test),
             new Parameter("@id_modulo", request.id_modulo),
             new Parameter("@id_recomendacion", request.id_recomendacion),
        };

        var result = ExecuteReader<PreguntaResponse>(
            "USP_DAT_PREGUNTA_LISTAR",
            CommandType.StoredProcedure, ref parms);

        return await Task.FromResult(result);
    }
}