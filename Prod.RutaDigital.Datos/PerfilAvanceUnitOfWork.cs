using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;
using Release.Helper.Data.Core;
using System.Data;

namespace Prod.RutaDigital.Datos
{
    public partial class UnitOfWork : IUnitOfWork
    {
        public async Task<IEnumerable<PerfilAvanceEstadisticaResponse>> ListarEstadisticaPerfilAvance
            (UsuarioExtranet request)
        {
            var parms = new Parameter[]
            {
                new Parameter("@id_usuario_extranet", request.id_usuario_extranet),
            };

            var result = ExecuteReader<PerfilAvanceEstadisticaResponse>(
                "USP_ESTADISTICA_PERFIL_AVANCE_LISTAR",
                CommandType.StoredProcedure, ref parms);

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<PerfilAvancePremioConsumoResponse>> ListarPremioConsumoPerfilAvance
            (UsuarioExtranet request)
        {
            var parms = new Parameter[]
            {
                new Parameter("@id_usuario_extranet", request.id_usuario_extranet),
            };

            var result = ExecuteReader<PerfilAvancePremioConsumoResponse>(
                "USP_PREMIO_CONSUMO_PERFIL_AVANCE_LISTAR",
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
                "USP_DAT_RESULTADO_PERFIL_AVANCE_LISTAR",
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
                "USP_DAT_RESULTADO_MODULO_PERFIL_AVANCE_LISTAR",
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

        public async Task<IEnumerable<RecomendacionResponse>> ListarCapacitacionPerfilAvance(UsuarioExtranet request)
        {
            var parms = new Parameter[]
            {
                new Parameter("@id_usuario_extranet", request.id_usuario_extranet)
            };

            var result = ExecuteReader<RecomendacionResponse>(
                "USP_DAT_CAPACITACION_PERFIL_AVANCE_LISTAR",
                CommandType.StoredProcedure, ref parms);

            return await Task.FromResult(result);
        }
    }
}
