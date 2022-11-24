using Release.Helper;
using Release.Helper.Proxy;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys;

public class NivelMadurezConsultaProxy : BaseProxy
{
    private readonly string _url;

    public NivelMadurezConsultaProxy(AppConfig appConfig,
        IHttpClientFactory httpClientFactory)
        : base(httpClientFactory)
    {
        _url = string.Format("{0}NivelMadurezConsulta/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
    }

    public async Task<StatusResponse<IEnumerable<NivelMadurezResponse>>>
        ListarNivelesMadurez()
    {
        return await CallWebApiAsync<StatusResponse<IEnumerable<NivelMadurezResponse>>>(
            HttpMethod.Get, 
            _url + "ListarNivelesMadurez");
    }
}
