using Release.Helper;
using Release.Helper.ProxyV2;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys;

public class ModuloConsultaProxy : BaseProxy
{
    private readonly string _url;

    public ModuloConsultaProxy(AppConfig appConfig,
        IHttpClientFactory httpClientFactory)
        : base(httpClientFactory)
    {
        _url = string.Format("{0}ModuloConsulta/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
    }

    public async Task<StatusResponse<IEnumerable<ModuloResponse>>>
        ListarModulos(ModuloRequest request)
    {
        return await CallWebApiAsync<StatusResponse<IEnumerable<ModuloResponse>>>(
            HttpMethod.Get,
            _url + "ListarModulos",
            GetJsonParameters(request));
    }
}
