using Release.Helper;
using Release.Helper.Proxy;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys;

public class RecursoDetConsultaProxy : BaseProxy
{
    private readonly string _url;

    public RecursoDetConsultaProxy(AppConfig appConfig)
    {
        _url = string.Format("{0}RecursoDetConsulta/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
    }

    public async Task<StatusResponse<IEnumerable<RecursoDetResponse>>>
        ListarRecursoDetalles(RecursoDetRequest request)
    {
        return await InvokeWebApiAsync<StatusResponse<IEnumerable<RecursoDetResponse>>>(
            HttpMethod.Get,
            _url + "ListarRecursoDetalles",
            GetJsonParameters(request));
    }
}
