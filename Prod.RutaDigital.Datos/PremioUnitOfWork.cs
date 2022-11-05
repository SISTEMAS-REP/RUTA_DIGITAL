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
    public class PremioUnitOfWork : UnitOfWork, IPremioUnitOfWork
    {
        public PremioUnitOfWork(IDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<PremioPublicidadResponse>> ListarPublicidadPremio()
        {
            var parms = new Parameter[]
            {
                
            };

            var result = ExecuteReader<PremioPublicidadResponse>(
                "Usp_listar_publicidad_premio",
                CommandType.StoredProcedure, ref parms).ToList();

            return await Task.FromResult(result);

        }

        public async Task<IEnumerable<PremioTipoResponse>> ListarTipoPremio()
        {
            var parms = new Parameter[]
            {

            };

            var result = ExecuteReader<PremioTipoResponse>(
                "Usp_listar_publicidad_premio",
                CommandType.StoredProcedure, ref parms).ToList();

            return await Task.FromResult(result);

        }
    }
}
