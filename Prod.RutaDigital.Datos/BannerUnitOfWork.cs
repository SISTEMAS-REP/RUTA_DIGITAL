using Prod.RutaDigital.Datos.Comun;
using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;
using Release.Helper.Data.Core;
using System.Data;

namespace Prod.RutaDigital.Datos;
public class BannerUnitOfWork : UnitOfWork, IBannerUnitOfWork
{
    public BannerUnitOfWork(IDbContext context)
   : base(context)
    {
    }

    public async Task<IEnumerable<BannerResponse>> ListarBannerPrincipal()
    {
        var parms = new Parameter[]
        {
            
        };

        var result = ExecuteReader<BannerResponse>(
            "Usp_listar_publicidad_inicio",
            CommandType.StoredProcedure, ref parms).ToList();

        return await Task.FromResult(result);

    }

    public async Task<IEnumerable<BannerResponse>> ListarBannerPiePagina()
    {
        var parms = new Parameter[]
         {

         };

        var result = ExecuteReader<BannerResponse>(
            "Usp_listar_publicidad_inicio",
            CommandType.StoredProcedure, ref parms).ToList();

        return await Task.FromResult(result);
    }

}
