using Release.Helper;
using Release.Helper.Proxy;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys;

public class RecursoConsultaProxy : BaseProxy
{
    private readonly string _url;

    public RecursoConsultaProxy(AppConfig appConfig)
    {
        _url = string.Format("{0}RecursoConsulta/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
    }

    public async Task<StatusResponse<IEnumerable<RecursoResponse>>>
        ListarRecursos(RecursoRequest request)
    {
        return await InvokeWebApiAsync<StatusResponse<IEnumerable<RecursoResponse>>>(
            HttpMethod.Get,
            _url + "ListarRecursos",
            GetJsonParameters(request));
    }
}
