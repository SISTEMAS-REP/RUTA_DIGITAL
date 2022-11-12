using Release.Helper;
using Release.Helper.Proxy;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys;

public class PremioConsultaProxy : BaseProxy
{
    private readonly string _url;

    public PremioConsultaProxy(AppConfig appConfig,
        IHttpClientFactory httpClientFactory)
        : base(httpClientFactory)
    {
        _url = string.Format("{0}PremioConsulta/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
    }

    public Task<StatusResponse<IEnumerable<PremioResponse>>>
        ListarPremios(PremioRequest request)
    {
        return CallWebApiAsync<StatusResponse<IEnumerable<PremioResponse>>>(
            HttpMethod.Get, 
            _url + "ListarPremios", 
            GetJsonParameters(request));
    }

    public Task<StatusResponse<IEnumerable<Premio>>>
        ListarPuntajesPremios()
    {
        return CallWebApiAsync<StatusResponse<IEnumerable<Premio>>>(
            HttpMethod.Get, 
            _url + "ListarPuntajesPremios");
    }
}
