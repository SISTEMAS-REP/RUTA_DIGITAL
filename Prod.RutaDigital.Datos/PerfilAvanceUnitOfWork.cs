using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;
using Release.Helper.Data.Core;
using System.Data;

namespace Prod.RutaDigital.Datos
{
    public partial class UnitOfWork : IUnitOfWork
    {
        public async Task<IEnumerable<CalculoPuntosResponse>> ListarCalculoPuntosUsuario
            (UsuarioExtranet request)
        {
            var parms = new Parameter[]
            {
                new Parameter("@id_usuario_extranet", request.id_usuario_extranet),
            };

            var result = ExecuteReader<CalculoPuntosResponse>(
                "USP_CALCULO_PUNTOS_USUARIO_LISTAR",
                CommandType.StoredProcedure, ref parms);

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<PremioConsumoResponse>> ListarPremioConsumoUsuario
            (UsuarioExtranet request)
        {
            var parms = new Parameter[]
            {
                new Parameter("@id_usuario_extranet", request.id_usuario_extranet),
            };

            var result = ExecuteReader<PremioConsumoResponse>(
                "USP_DAT_PREMIO_CONSUMO_USUARIO_LISTAR",
                CommandType.StoredProcedure, ref parms);

            return await Task.FromResult(result);
        }
    }
}
