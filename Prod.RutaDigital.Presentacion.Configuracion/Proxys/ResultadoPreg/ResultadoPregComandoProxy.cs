using Release.Helper;
using Release.Helper.ProxyV2;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys;

public class ResultadoPregComandoProxy : BaseProxy
{
    private readonly string _url;

    public ResultadoPregComandoProxy(AppConfig appConfig,
        IHttpClientFactory httpClientFactory)
        : base(httpClientFactory)
    {
        _url = string.Format("{0}ResultadoPregComando/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
    }

    public async Task<StatusResponse<int>>
        InsertarResultadoPreg(ResultadoPregRequest request)
    {
        return await CallWebApiAsync<StatusResponse<int>>(
            HttpMethod.Post,
            _url + "InsertarResultadoPreg",
            GetJsonParameters(request));
    }
}
