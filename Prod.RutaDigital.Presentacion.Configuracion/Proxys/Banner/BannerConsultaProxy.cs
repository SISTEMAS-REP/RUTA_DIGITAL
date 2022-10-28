using Prod.RutaDigital.Entidades;
using Release.Helper;
using Release.Helper.Proxy;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys
{
    public class BannerConsultaProxy : BaseProxy
    {
        private readonly string _url;
        public BannerConsultaProxy(AppConfig appConfig,
        IHttpClientFactory httpClientFactory)
        : base(httpClientFactory)
        {
            _url = string.Format("{0}BannerConsulta/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
        }

        public Task<StatusResponse<List<BannerResponse>>> ListarBannerPrincipal()
        {
            return this.CallWebApiAsync<StatusResponse<List<BannerResponse>>>(HttpMethod.Get, _url + "ListarBannerPrincipal", null);
        }
        public Task<StatusResponse<List<BannerResponse>>> ListarBannerPiePagina()
        {
            return base.CallWebApiAsync<StatusResponse<List<BannerResponse>>>(verb: HttpMethod.Get, urlAction: _url + "ListarBannerPiePagina", null);
        }
    }
}
