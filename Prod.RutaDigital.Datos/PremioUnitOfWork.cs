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
                "USP_LISTAR_PUBLICIDAD_PREMIO",
                CommandType.StoredProcedure, ref parms).ToList();

            return await Task.FromResult(result);

        }

        public async Task<IEnumerable<PremioTipoResponse>> ListarTipoPremio()
        {
            var parms = new Parameter[]
            {

            };

            var result = ExecuteReader<PremioTipoResponse>(
                "USP_LISTAR_TIPO_PREMIO",
                CommandType.StoredProcedure, ref parms).ToList();

            return await Task.FromResult(result);

        }

        public async Task<IEnumerable<PremioResponse>> ListarPremio(PremioRequest request)
        {
            var parms = new Parameter[]
            {
                new Parameter("@CantReg", request.CantReg),
            };

            var result = ExecuteReader<PremioResponse>(
                "USP_LISTAR_PREMIOS",
                CommandType.StoredProcedure, ref parms).ToList();

            return await Task.FromResult(result);

        }
    }
}
