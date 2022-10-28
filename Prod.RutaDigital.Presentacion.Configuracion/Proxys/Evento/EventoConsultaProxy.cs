using Prod.RutaDigital.Entidades;
using Release.Helper;
using Release.Helper.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Task<StatusResponse<List<EventoResponse>>> ListarEventos()
        {
            return this.CallWebApiAsync<StatusResponse<List<EventoResponse>>>(HttpMethod.Get, _url + "ListarEventos", null);
        }
    }
}
