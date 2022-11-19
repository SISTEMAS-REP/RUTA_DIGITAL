using Release.Helper;
using Release.Helper.ProxyV2;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys;

public class CapacitacionResultadoComandoProxy : BaseProxy
{
    private readonly string _url;

    public CapacitacionResultadoComandoProxy(AppConfig appConfig,
        IHttpClientFactory httpClientFactory)
        : base(httpClientFactory)
    {
        _url = string.Format("{0}CapacitacionResultadoComando/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
    }

    public async Task<StatusResponse<int>>
        InsertarCapacitacionResultado(CapacitacionResultadoRequest request)
    {
        return await CallWebApiAsync<StatusResponse<int>>(
            HttpMethod.Post,
            _url + "InsertarCapacitacionResultado",
            GetJsonParameters(request));
    }

    public async Task<StatusResponse<int>>
        ActualizarCapacitacionResultado(CapacitacionResultadoRequest request)
    {
        return await CallWebApiAsync<StatusResponse<int>>(
            HttpMethod.Put,
            _url + "ActualizarCapacitacionResultado",
            GetJsonParameters(request));
    }
}
