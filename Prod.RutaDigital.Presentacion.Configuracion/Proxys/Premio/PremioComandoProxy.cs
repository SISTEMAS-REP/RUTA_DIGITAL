using Prod.RutaDigital.Entidades;
using Release.Helper;
using Release.Helper.Proxy;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys
{
    public class PremioComandoProxy : BaseProxy
    {

        private readonly string _url;

        public PremioComandoProxy(AppConfig appConfig)
        {
            _url = string.Format("{0}PremioComando/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
        }

        public Task<StatusResponse<PremioCanjeResponse>> CanjePremio(PremioCanjeRequest request)
        {
            return InvokeWebApiAsync<StatusResponse<PremioCanjeResponse>>(HttpMethod.Post,_url + "CanjePremio", GetJsonParameters(request));
        }
    }
}
