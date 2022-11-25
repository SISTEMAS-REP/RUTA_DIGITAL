using Release.Helper;
using Release.Helper.Proxy;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys;

public class UsuarioExtranetConsultaProxy : BaseProxy
{
    private readonly string _url;

    public UsuarioExtranetConsultaProxy(AppConfig appConfig)
    {
        _url = string.Format("{0}UsuarioExtranetConsulta/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
    }

    public async Task<StatusResponse<UsuarioExtranetResponse>>
        BuscarUsuario(UsuarioExtranetRequest request)
    {
        return await InvokeWebApiAsync<StatusResponse<UsuarioExtranetResponse>>(
            HttpMethod.Get,
            _url + "BuscarUsuario",
            GetJsonParameters(request));
    }
}
