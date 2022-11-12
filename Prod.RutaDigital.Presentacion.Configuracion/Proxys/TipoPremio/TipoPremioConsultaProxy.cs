using Release.Helper;
using Release.Helper.Proxy;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys;

public class TipoPremioConsultaProxy : BaseProxy
{
    private readonly string _url;

    public TipoPremioConsultaProxy(AppConfig appConfig,
        IHttpClientFactory httpClientFactory)
        : base(httpClientFactory)
    {
        _url = string.Format("{0}TipoPremioConsulta/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
    }

    public async Task<StatusResponse<IEnumerable<TipoPremio>>>
        ListarTiposPremio()
    {
        return await CallWebApiAsync<StatusResponse<IEnumerable<TipoPremio>>>(
            HttpMethod.Get, 
            _url + "ListarTiposPremio");
    }
}
