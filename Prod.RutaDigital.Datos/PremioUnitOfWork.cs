using System.Data;
using Release.Helper.Data.Core;

using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Datos;

public partial class UnitOfWork : IUnitOfWork
{
    public async Task<IEnumerable<PremioResponse>> 
        ListarPremios(PremioRequest request)
    {
        var parms = new Parameter[]
        {
            new Parameter("@CantReg", request.CantReg),
            new Parameter("@IdListCatalogo", request.IdListCatalogo),
            new Parameter("@IdPremio", request.id_premio),
            new Parameter("@IdTipo", request.IdTipo),
            new Parameter("@IdNivel", request.IdNivel),
            new Parameter("@PuntosDesde", request.PuntosDesde),
            new Parameter("@PuntosHasta", request.PuntosHasta),
        };

        var result = ExecuteReader<PremioResponse>(
            "USP_LISTAR_PREMIOS",
            CommandType.StoredProcedure, ref parms);

         return await Task.FromResult(result);
    }

    public async Task<IEnumerable<Premio>> 
        ListarPuntajesPremios()
    {
        var parms = new Parameter[]
        {

        };

        var result = ExecuteReader<Premio>(
            "USP_LISTAR_PUNTAJE_PREMIO",
            CommandType.StoredProcedure, ref parms);

        return await Task.FromResult(result);
    }
}
