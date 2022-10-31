using Prod.RutaDigital.Entidades;
using Release.Helper;
using Release.Helper.Proxy;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys
{
    public class EventoConsultaProxy : BaseProxy
    {
        private readonly string _url;
        public EventoConsultaProxy(AppConfig appConfig,
        IHttpClientFactory httpClientFactory)
        : base(httpClientFactory)
        {
            _url = string.Format("{0}EventoConsulta/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
        }
        public Task<StatusResponse<List<EventoResponse>>> ListarEventos(EventoRequest request)
        {
            return this.CallWebApiAsync<StatusResponse<List<EventoResponse>>>(HttpMethod.Get, _url + "ListarEventos", this.GetJsonParameters(request));
        }
    }
}
