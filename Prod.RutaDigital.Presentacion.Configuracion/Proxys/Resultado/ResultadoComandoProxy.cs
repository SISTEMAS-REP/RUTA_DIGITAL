using Release.Helper;
using Release.Helper.ProxyV2;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys;

public class ResultadoComandoProxy : BaseProxy
{
    private readonly string _url;

    public ResultadoComandoProxy(AppConfig appConfig,
        IHttpClientFactory httpClientFactory)
        : base(httpClientFactory)
    {
        _url = string.Format("{0}ResultadoComando/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
    }

    public async Task<StatusResponse<int>>
        InsertarResultado(ResultadoRequest request)
    {
        return await CallWebApiAsync<StatusResponse<int>>(
            HttpMethod.Post,
            _url + "InsertarResultado",
            GetJsonParameters(request));
    }
}
