using Release.Helper;
using Release.Helper.ProxyV2;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys;

public class PreguntaConsultaProxy : BaseProxy
{
    private readonly string _url;

    public PreguntaConsultaProxy(AppConfig appConfig,
        IHttpClientFactory httpClientFactory)
        : base(httpClientFactory)
    {
        _url = string.Format("{0}PreguntaConsulta/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
    }

    public async Task<StatusResponse<IEnumerable<PreguntaResponse>>>
        ListarPreguntas(PreguntaRequest request)
    {
        return await CallWebApiAsync<StatusResponse<IEnumerable<PreguntaResponse>>>(
            HttpMethod.Get,
            _url + "ListarPreguntas",
            GetJsonParameters(request));
    }
}
