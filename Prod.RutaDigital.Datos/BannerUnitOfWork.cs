using Prod.RutaDigital.Datos.Comun;
using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;
using Release.Helper.Data.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod.RutaDigital.Datos
{
    public class BannerUnitOfWork : UnitOfWork, IBannerUnitOfWork
    {
        public BannerUnitOfWork(IDbContext context)
       : base(context)
        {
        }

        public async Task<List<BannerResponse>> ListarBannerPrincipal()
        {
            var parms = new Parameter[]
            {
           
            };

            var result = ExecuteReader<BannerResponse>(
                "usr_login_unico.sp_GetApliacionesByUsuario",
                CommandType.StoredProcedure, ref parms).ToList();

            return await Task.FromResult(result);
        }

        public async Task<List<BannerResponse>> ListarBannerPiePagina()
        {
            var parms = new Parameter[]
            {

            };

            var result = ExecuteReader<BannerResponse>(
                "usr_login_unico.sp_GetApliacionesByUsuario",
                CommandType.StoredProcedure, ref parms).ToList();

            return await Task.FromResult(result);
        }

    }
}
