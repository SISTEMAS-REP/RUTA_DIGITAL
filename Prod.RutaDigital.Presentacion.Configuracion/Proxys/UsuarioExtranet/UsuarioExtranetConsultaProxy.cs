using Release.Helper;
using Release.Helper.ProxyV2;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys;

public class UsuarioExtranetConsultaProxy : BaseProxy
{
    private readonly string _url;

    public UsuarioExtranetConsultaProxy(AppConfig appConfig,
        IHttpClientFactory httpClientFactory)
        : base(httpClientFactory)
    {
        _url = string.Format("{0}UsuarioExtranetConsulta/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
    }

    public async Task<StatusResponse<UsuarioExtranetResponse>>
        BuscarUsuario(UsuarioExtranetRequest request)
    {
        return await CallWebApiAsync<StatusResponse<UsuarioExtranetResponse>>(
            HttpMethod.Get,
            _url + "BuscarUsuario",
            GetJsonParameters(request));
    }
}
