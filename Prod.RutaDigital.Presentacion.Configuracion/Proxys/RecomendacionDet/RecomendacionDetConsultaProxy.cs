using Release.Helper;
using Release.Helper.Proxy;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys;

public class RecomendacionDetConsultaProxy : BaseProxy
{
    private readonly string _url;

    public RecomendacionDetConsultaProxy(AppConfig appConfig)
    {
        _url = string.Format("{0}RecomendacionDetConsulta/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
    }

    public async Task<StatusResponse<IEnumerable<RecomendacionDetResponse>>>
        ListarRecomendacionDetalles(RecomendacionDetRequest request)
    {
        return await InvokeWebApiAsync<StatusResponse<IEnumerable<RecomendacionDetResponse>>>(
            HttpMethod.Get,
            _url + "ListarRecomendacionDetalles",
            GetJsonParameters(request));
    }
}
