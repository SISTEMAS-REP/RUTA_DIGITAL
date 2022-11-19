using Release.Helper;
using Release.Helper.ProxyV2;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys;

public class TipoTestConsultaProxy : BaseProxy
{
    private readonly string _url;

    public TipoTestConsultaProxy(AppConfig appConfig,
        IHttpClientFactory httpClientFactory)
        : base(httpClientFactory)
    {
        _url = string.Format("{0}TipoTestConsulta/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
    }

    public async Task<StatusResponse<IEnumerable<TipoTestResponse>>>
        ListarTiposTest(TipoTestRequest request)
    {
        return await CallWebApiAsync<StatusResponse<IEnumerable<TipoTestResponse>>>(
            HttpMethod.Get,
            _url + "ListarTiposTest",
            GetJsonParameters(request));
    }
}
