using Release.Helper;
using Release.Helper.ProxyV2;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys;

public class EvaluacionComandoProxy : BaseProxy
{
    private readonly string _url;

    public EvaluacionComandoProxy(AppConfig appConfig,
        IHttpClientFactory httpClientFactory)
        : base(httpClientFactory)
    {
        _url = string.Format("{0}EvaluacionComando/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
    }

    public async Task<StatusResponse<int>>
        InsertarEvaluacion(EvaluacionRequest request)
    {
        return await CallWebApiAsync<StatusResponse<int>>(
            HttpMethod.Post,
            _url + "InsertarEvaluacion",
            GetJsonParameters(request));
    }

    public async Task<StatusResponse<int>>
        ActualizarEvaluacion(EvaluacionRequest request)
    {
        return await CallWebApiAsync<StatusResponse<int>>(
            HttpMethod.Put,
            _url + "ActualizarEvaluacion",
            GetJsonParameters(request));
    }
}
