using Prod.RutaDigital.Entidades;
using Release.Helper;
using Release.Helper.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys.Comun
{
    public class ComunConsultaProxy : BaseProxy
    {
        private readonly string _url;
        public ComunConsultaProxy(AppConfig appConfig,
        IHttpClientFactory httpClientFactory)
        : base(httpClientFactory)
        {
            _url = string.Format("{0}ComunConsulta/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
        }

        public Task<StatusResponse<LoginUnicoResponse>> VerificarAutoDiagnosticoHistorico(LoginUnicoRequest request)
        {
            return this.CallWebApiAsync<StatusResponse<LoginUnicoResponse>>(HttpMethod.Get, _url + "VerificarAutoDiagnosticoHistorico", this.GetJsonParameters(request));
        }

        public Task<StatusResponse<LoginUnicoResponse>> VerificarAutoDiagnostico(LoginUnicoRequest request)
        {
            return this.CallWebApiAsync<StatusResponse<LoginUnicoResponse>>(HttpMethod.Get, _url + "VerificarAutoDiagnostico", this.GetJsonParameters(request));
        }
    }
}
