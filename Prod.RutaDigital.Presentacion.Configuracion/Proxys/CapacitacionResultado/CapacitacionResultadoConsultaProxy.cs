using Release.Helper;
using Release.Helper.ProxyV2;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys;

public class CapacitacionResultadoConsultaProxy : BaseProxy
{
    private readonly string _url;

    public CapacitacionResultadoConsultaProxy(AppConfig appConfig,
        IHttpClientFactory httpClientFactory)
        : base(httpClientFactory)
    {
        _url = string.Format("{0}CapacitacionResultadoConsulta/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
    }

    public async Task<StatusResponse<IEnumerable<CapacitacionResultadoResponse>>>
        ListarCapacitacionesResultado(CapacitacionResultadoRequest request)
    {
        return await CallWebApiAsync<StatusResponse<IEnumerable<CapacitacionResultadoResponse>>>(
            HttpMethod.Get,
            _url + "ListarCapacitacionesResultado",
            GetJsonParameters(request));
    }
}
