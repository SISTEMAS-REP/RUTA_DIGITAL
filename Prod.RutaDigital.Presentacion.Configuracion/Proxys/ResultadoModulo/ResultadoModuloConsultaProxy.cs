using Release.Helper;
using Release.Helper.ProxyV2;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys;

public class ResultadoModuloConsultaProxy : BaseProxy
{
    private readonly string _url;

    public ResultadoModuloConsultaProxy(AppConfig appConfig,
        IHttpClientFactory httpClientFactory)
        : base(httpClientFactory)
    {
        _url = string.Format("{0}ResultadoModuloConsulta/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
    }

    public async Task<StatusResponse<IEnumerable<ResultadoModuloResponse>>>
        ListarResultadoModulos(ResultadoModuloRequest request)
    {
        return await CallWebApiAsync<StatusResponse<IEnumerable<ResultadoModuloResponse>>>(
            HttpMethod.Get,
            _url + "ListarResultadoModulos",
            GetJsonParameters(request));
    }
}
