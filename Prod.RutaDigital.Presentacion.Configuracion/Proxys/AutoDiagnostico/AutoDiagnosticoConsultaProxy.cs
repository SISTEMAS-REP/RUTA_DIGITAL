using Prod.RutaDigital.Entidades;
using Release.Helper;
using Release.Helper.ProxyV2;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys.AutoDiagnostico
{
    public class AutoDiagnosticoConsultaProxy : BaseProxy
    {
        private readonly string _url;

        public AutoDiagnosticoConsultaProxy(AppConfig appConfig,
            IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        {
            _url = string.Format("{0}AutoDiagnosticoConsulta/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
        }

        public async Task<StatusResponse<AutoDiagnosticoResponse>> VerificarAutoDiagnosticoHistorico(AutoDiagnosticoRequest request)
        {
            return await this.CallWebApiAsync<StatusResponse<AutoDiagnosticoResponse>>(HttpMethod.Get, _url + "VerificarAutoDiagnosticoHistorico", this.GetJsonParameters(request));
        }

        public async Task<StatusResponse<AutoDiagnosticoResponse>> VerificarAutoDiagnostico(AutoDiagnosticoRequest request)
        {
            return await this.CallWebApiAsync<StatusResponse<AutoDiagnosticoResponse>>(HttpMethod.Get, _url + "VerificarAutoDiagnostico", this.GetJsonParameters(request));
        }
    }
}
