using Release.Helper;
using Release.Helper.ProxyV2;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys;

public class AlternativaConsultaProxy : BaseProxy
{
    private readonly string _url;

    public AlternativaConsultaProxy(AppConfig appConfig,
        IHttpClientFactory httpClientFactory)
        : base(httpClientFactory)
    {
        _url = string.Format("{0}AlternativaConsulta/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
    }

    public async Task<StatusResponse<IEnumerable<AlternativaResponse>>>
        ListarAlternativas(AlternativaRequest request)
    {
        return await CallWebApiAsync<StatusResponse<IEnumerable<AlternativaResponse>>>(
            HttpMethod.Get,
            _url + "ListarAlternativas",
            GetJsonParameters(request));
    }
}
