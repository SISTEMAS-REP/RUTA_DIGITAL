using Release.Helper;
using Release.Helper.Proxy;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys;

public class PublicidadConsultaProxy : BaseProxy
{
    private readonly string _url;

    public PublicidadConsultaProxy(AppConfig appConfig,
        IHttpClientFactory httpClientFactory)
        : base(httpClientFactory)
    {
        _url = string.Format("{0}PublicidadConsulta/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
    }

    public async Task<StatusResponse<IEnumerable<Publicidad>>>
        ListarPublicidad()
    {
        return await CallWebApiAsync<StatusResponse<IEnumerable<Publicidad>>>(
            HttpMethod.Get, 
            _url + "ListarPublicidad");
    }
}
