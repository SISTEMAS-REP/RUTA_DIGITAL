using Release.Helper;
using Release.Helper.ProxyV2;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys;

public class RespuestaConsultaProxy : BaseProxy
{
    private readonly string _url;

    public RespuestaConsultaProxy(AppConfig appConfig,
        IHttpClientFactory httpClientFactory)
        : base(httpClientFactory)
    {
        _url = string.Format("{0}RespuestaConsulta/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
    }

    public async Task<StatusResponse<IEnumerable<RespuestaResponse>>>
        ListarRespuestas(RespuestaRequest request)
    {
        return await CallWebApiAsync<StatusResponse<IEnumerable<RespuestaResponse>>>(
            HttpMethod.Get,
            _url + "ListarRespuestas",
            GetJsonParameters(request));
    }
}
