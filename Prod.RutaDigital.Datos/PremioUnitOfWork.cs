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
                new Parameter("@IdListCatalogo", request.IdListCatalogo),
                new Parameter("@IdPremio", request.id_premio),
                new Parameter("@IdTipo", request.IdTipo),
                new Parameter("@IdNivel", request.IdNivel),
                new Parameter("@PuntosDesde", request.PuntosDesde),
                new Parameter("@PuntosHasta", request.PuntosHasta),
            };

            var result = ExecuteReader<PremioResponse>(
                "USP_LISTAR_PREMIOS",
                CommandType.StoredProcedure, ref parms).ToList();

             return await Task.FromResult(result);

        }

        public async Task<IEnumerable<PremioNivelResponse>> ListarNivelPremio()
        {
            var parms = new Parameter[]
            {

            };

            var result = ExecuteReader<PremioNivelResponse>(
                "USP_LISTAR_NIVEL_MADUREZ",
                CommandType.StoredProcedure, ref parms).ToList();

            return await Task.FromResult(result);

        }

        public async Task<IEnumerable<PremioPuntajeResponse>> ListarPuntajePremio()
        {
            var parms = new Parameter[]
            {

            };

            var result = ExecuteReader<PremioPuntajeResponse>(
                "USP_LISTAR_PUNTAJE_PREMIO",
                CommandType.StoredProcedure, ref parms).ToList();

            return await Task.FromResult(result);

        }
    }
}
