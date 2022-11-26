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
                _url + "ListarNivelesMadurez", GetJsonParameters(request));
        }

        public async Task<StatusResponse<IEnumerable<PremioConsumoResponse>>> ListarPremioConsumoUsuario(UsuarioExtranet request)
        {
            return await InvokeWebApiAsync<StatusResponse<IEnumerable<PremioConsumoResponse>>>(
                HttpMethod.Get,
                _url + "ListarNivelesMadurez", GetJsonParameters(request));
        }

    }
}
