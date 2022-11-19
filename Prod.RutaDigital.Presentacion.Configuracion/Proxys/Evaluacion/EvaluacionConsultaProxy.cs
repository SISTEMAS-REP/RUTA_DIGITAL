using Release.Helper;
using Release.Helper.ProxyV2;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys;

public class EvaluacionConsultaProxy : BaseProxy
{
    private readonly string _url;

    public EvaluacionConsultaProxy(AppConfig appConfig,
        IHttpClientFactory httpClientFactory)
        : base(httpClientFactory)
    {
        _url = string.Format("{0}EvaluacionConsulta/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
    }

    public async Task<StatusResponse<IEnumerable<EvaluacionResponse>>>
        ListarEvaluacion(EvaluacionRequest request)
    {
        return await CallWebApiAsync<StatusResponse<IEnumerable<EvaluacionResponse>>>(
            HttpMethod.Get,
            _url + "ListarEvaluacion",
            GetJsonParameters(request));
    }
}
