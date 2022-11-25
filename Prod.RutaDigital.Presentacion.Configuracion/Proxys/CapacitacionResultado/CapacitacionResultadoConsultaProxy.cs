using Release.Helper;

using Prod.RutaDigital.Entidades;
using Release.Helper.Proxy;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys;

public class CapacitacionResultadoConsultaProxy : BaseProxy
{
    private readonly string _url;

    public CapacitacionResultadoConsultaProxy(AppConfig appConfig)
    {
        _url = string.Format("{0}CapacitacionResultadoConsulta/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
    }

    public async Task<StatusResponse<IEnumerable<CapacitacionResultadoResponse>>>
        ListarCapacitacionesResultado(CapacitacionResultadoRequest request)
    {
        return await InvokeWebApiAsync<StatusResponse<IEnumerable<CapacitacionResultadoResponse>>>(
            HttpMethod.Get,
            _url + "ListarCapacitacionesResultado",
            GetJsonParameters(request));
    }
}
