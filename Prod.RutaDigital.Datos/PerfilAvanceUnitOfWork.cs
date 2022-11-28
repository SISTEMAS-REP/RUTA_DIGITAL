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

        public async Task<IEnumerable<ResultadoResponse>>
        ListarResultadosPerfilAvance(ResultadoRequest request)
        {
            var parms = new Parameter[]
            {
             new Parameter("@id_resultado", request.id_resultado),
             new Parameter("@id_evaluacion", request.id_evaluacion),
             new Parameter("@id_tipo_test", request.id_tipo_test),
             new Parameter("@id_usuario_extranet", request.id_usuario_extranet)
            };

            var result = ExecuteReader<ResultadoResponse>(
                "USP_DAT_RESULTADO_LISTAR",
                CommandType.StoredProcedure, ref parms);

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<ResultadoModuloResponse>>
        ListarResultadoModulosPerfilAvance(ResultadoModuloRequest request)
        {
            var parms = new Parameter[]
            {
             new Parameter("@id_resultado_modulo", request.id_resultado_modulo),
             new Parameter("@id_resultado", request.id_resultado),
             new Parameter("@id_modulo", request.id_modulo),
            };

            var result = ExecuteReader<ResultadoModuloResponse>(
                "USP_DAT_RESULTADO_MODULO_LISTAR",
                CommandType.StoredProcedure, ref parms);

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<NivelMadurezResponse>>
       ListarNivelesMadurezPerfilAvance()
        {
            var parms = new Parameter[]
            {

            };

            var result = ExecuteReader<NivelMadurezResponse>(
                "USP_CAT_NIVEL_MADUREZ_LISTAR",
                CommandType.StoredProcedure, ref parms);

            return await Task.FromResult(result);
        }
    }
}
