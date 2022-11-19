using Release.Helper;
using Release.Helper.ProxyV2;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys;

public class ResultadoModuloComandoProxy : BaseProxy
{
    private readonly string _url;

    public ResultadoModuloComandoProxy(AppConfig appConfig,
        IHttpClientFactory httpClientFactory)
        : base(httpClientFactory)
    {
        _url = string.Format("{0}ResultadoModuloComando/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
    }

    public async Task<StatusResponse<int>>
        InsertarResultadoModulo(ResultadoModuloRequest request)
    {
        return await CallWebApiAsync<StatusResponse<int>>(
            HttpMethod.Post,
            _url + "InsertarResultadoModulo",
            GetJsonParameters(request));
    }
}
