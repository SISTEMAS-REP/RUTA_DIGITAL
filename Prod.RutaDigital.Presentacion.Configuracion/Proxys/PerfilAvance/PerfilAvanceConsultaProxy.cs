using Release.Helper.Proxy;
namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys.PerfilAvance
{
    public class PerfilAvanceConsultaProxy : BaseProxy
    {
        private readonly string _url;

        public PerfilAvanceConsultaProxy(AppConfig appConfig,
            IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        {
            _url = string.Format("{0}PerfilAvanceConsulta/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
        }
    }
}
