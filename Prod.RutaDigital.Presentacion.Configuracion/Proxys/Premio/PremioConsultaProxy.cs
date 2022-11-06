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
    public class PremioConsultaProxy : BaseProxy
    {
        private readonly string _url;
        public PremioConsultaProxy(AppConfig appConfig,
        IHttpClientFactory httpClientFactory)
        : base(httpClientFactory)
        {
            _url = string.Format("{0}PremioConsulta/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
        }
        public Task<StatusResponse<List<PremioPublicidadResponse>>> ListarPublicidadPremio()
        {
            return this.CallWebApiAsync<StatusResponse<List<PremioPublicidadResponse>>>(HttpMethod.Get, _url + "ListarPublicidadPremio", null);
        }

        public Task<StatusResponse<List<PremioTipoResponse>>> ListarTipoPremio()
        {
            return this.CallWebApiAsync<StatusResponse<List<PremioTipoResponse>>>(HttpMethod.Get, _url + "ListarTipoPremio", null);
        }

        public Task<StatusResponse<List<PremioResponse>>> ListarPremio()
        {
            return this.CallWebApiAsync<StatusResponse<List<PremioResponse>>>(HttpMethod.Get, _url + "ListarPremio", null);
        }
    }
}
