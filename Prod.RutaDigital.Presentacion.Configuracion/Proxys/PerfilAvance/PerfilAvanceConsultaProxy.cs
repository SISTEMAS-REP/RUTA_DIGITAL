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

        public async Task<StatusResponse<IEnumerable<CalculoPuntosResponse>>> ListarCalculoPuntosUsuario(UsuarioExtranet request)
        {
            return await InvokeWebApiAsync<StatusResponse<IEnumerable<CalculoPuntosResponse>>>(
                HttpMethod.Get,
                _url + "ListarCalculoPuntosUsuario", GetJsonParameters(request));
        }

        public async Task<StatusResponse<IEnumerable<PremioConsumoResponse>>> ListarPremioConsumoUsuario(UsuarioExtranet request)
        {
            return await InvokeWebApiAsync<StatusResponse<IEnumerable<PremioConsumoResponse>>>(
                HttpMethod.Get,
                _url + "ListarPremioConsumoUsuario", GetJsonParameters(request));
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
    }
}
