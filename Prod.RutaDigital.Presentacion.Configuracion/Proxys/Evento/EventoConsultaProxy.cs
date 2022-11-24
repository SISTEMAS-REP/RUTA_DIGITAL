using Release.Helper;
using Release.Helper.ProxyV2;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys;

public class EventoConsultaProxy : BaseProxy
{
    private readonly string _url;

    public EventoConsultaProxy(AppConfig appConfig,
        IHttpClientFactory httpClientFactory)
        : base(httpClientFactory)
    {
        _url = string.Format("{0}EventoConsulta/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
    }

    public async Task<StatusResponse<IEnumerable<EventoResponse>>> 
        ListarEventos(EventoRequest request)
    {
        return await CallWebApiAsync<StatusResponse<IEnumerable<EventoResponse>>>(
            HttpMethod.Get, 
            _url + "ListarEventos", 
            GetJsonParameters(request));
    }
}
