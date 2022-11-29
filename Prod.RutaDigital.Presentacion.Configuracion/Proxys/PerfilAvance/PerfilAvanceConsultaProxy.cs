using Prod.RutaDigital.Entidades;
using Release.Helper;
using Release.Helper.Proxy;
namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys.PerfilAvance
{
    public class PerfilAvanceConsultaProxy : BaseProxy
    {
        private readonly string _url;

        public PerfilAvanceConsultaProxy(AppConfig appConfig)
        {
            _url = string.Format("{0}PerfilAvanceConsulta/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
        }

        public async Task<StatusResponse<IEnumerable<PerfilAvanceEstadisticaResponse>>> ListarEstadisticaPerfilAvance(UsuarioExtranet request)
        {
            return await InvokeWebApiAsync<StatusResponse<IEnumerable<PerfilAvanceEstadisticaResponse>>>(
                HttpMethod.Get,
                _url + "ListarEstadisticaPerfilAvance", GetJsonParameters(request));
        }

        public async Task<StatusResponse<IEnumerable<PerfilAvancePremioConsumoResponse>>> ListarPremioConsumoPerfilAvance(UsuarioExtranet request)
        {
            return await InvokeWebApiAsync<StatusResponse<IEnumerable<PerfilAvancePremioConsumoResponse>>>(
                HttpMethod.Get,
                _url + "ListarPremioConsumoPerfilAvance", GetJsonParameters(request));
        }
        public async Task<StatusResponse<IEnumerable<ResultadoResponse>>>
       ListarResultadosPerfilAvance(ResultadoRequest request)
        {
            return await InvokeWebApiAsync<StatusResponse<IEnumerable<ResultadoResponse>>>(
                HttpMethod.Get,
                _url + "ListarResultadosPerfilAvance",
                GetJsonParameters(request));
        }

        public async Task<StatusResponse<IEnumerable<ResultadoModuloResponse>>>
        ListarResultadoModulosPerfilAvance(ResultadoModuloRequest request)
        {
            return await InvokeWebApiAsync<StatusResponse<IEnumerable<ResultadoModuloResponse>>>(
                HttpMethod.Get,
                _url + "ListarResultadoModulosPerfilAvance",
                GetJsonParameters(request));
        }

        public async Task<StatusResponse<IEnumerable<NivelMadurezResponse>>>
        ListarNivelesMadurezPerfilAvance()
        {
            return await InvokeWebApiAsync<StatusResponse<IEnumerable<NivelMadurezResponse>>>(
                HttpMethod.Get,
                _url + "ListarNivelesMadurezPerfilAvance", null);
        }

        public async Task<StatusResponse<IEnumerable<RecomendacionResponse>>> ListarCapacitacionPerfilAvance(UsuarioExtranet request)
        {
            return await InvokeWebApiAsync<StatusResponse<IEnumerable<RecomendacionResponse>>>(
                HttpMethod.Get,
                _url + "ListarCapacitacionPerfilAvance", GetJsonParameters(request));
        }
    }
}
