using Release.Helper;
using Release.Helper.ProxyV2;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys;

public class RespuestaComandoProxy : BaseProxy
{
    private readonly string _url;

    public RespuestaComandoProxy(AppConfig appConfig,
        IHttpClientFactory httpClientFactory)
        : base(httpClientFactory)
    {
        _url = string.Format("{0}RespuestaComando/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
    }

    public async Task<StatusResponse<int>>
        InsertarRespuesta(RespuestaRequest request)
    {
        return await CallWebApiAsync<StatusResponse<int>>(
            HttpMethod.Post,
            _url + "InsertarRespuesta",
            GetJsonParameters(request));
    }

    public async Task<StatusResponse<int>>
        ActualizarRespuesta(RespuestaRequest request)
    {
        return await CallWebApiAsync<StatusResponse<int>>(
            HttpMethod.Put,
            _url + "ActualizarRespuesta",
            GetJsonParameters(request));
    }
}
