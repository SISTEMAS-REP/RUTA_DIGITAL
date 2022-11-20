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
    public class PremioComandoProxy : BaseProxy
    {

        private readonly string _url;

        public PremioComandoProxy(AppConfig appConfig,
            IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        {
            _url = string.Format("{0}PremioComando/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
        }

        public Task<StatusResponse<PremioCanjeResponse>> CanjePremio(PremioCanjeRequest request)
        {
            return CallWebApiAsync<StatusResponse<PremioCanjeResponse>>(HttpMethod.Get,_url + "CanjePremio", GetJsonParameters(request));
        }
    }
}
