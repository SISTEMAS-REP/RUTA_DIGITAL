using Release.Helper;
using Release.Helper.Proxy;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys;

public class RecomendacionConsultaProxy : BaseProxy
{
    private readonly string _url;

    public RecomendacionConsultaProxy(AppConfig appConfig)
    {
        _url = string.Format("{0}RecomendacionConsulta/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
    }

    public async Task<StatusResponse<IEnumerable<RecomendacionResponse>>>
        ListarRecomendaciones(RecomendacionRequest request)
    {
        return await InvokeWebApiAsync<StatusResponse<IEnumerable<RecomendacionResponse>>>(
            HttpMethod.Get,
            _url + "ListarRecomendaciones",
            GetJsonParameters(request));
    }
}
