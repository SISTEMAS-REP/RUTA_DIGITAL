using Release.Helper;
using Release.Helper.ProxyV2;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys;

public class ResultadoConsultaProxy : BaseProxy
{
    private readonly string _url;

    public ResultadoConsultaProxy(AppConfig appConfig,
        IHttpClientFactory httpClientFactory)
        : base(httpClientFactory)
    {
        _url = string.Format("{0}ResultadoConsulta/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
    }

    public async Task<StatusResponse<IEnumerable<ResultadoResponse>>>
        ListarResultados(ResultadoRequest request)
    {
        return await CallWebApiAsync<StatusResponse<IEnumerable<ResultadoResponse>>>(
            HttpMethod.Get,
            _url + "ListarResultados",
            GetJsonParameters(request));
    }
}
