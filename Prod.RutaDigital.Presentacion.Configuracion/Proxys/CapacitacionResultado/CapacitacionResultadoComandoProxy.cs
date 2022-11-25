using Release.Helper;

using Prod.RutaDigital.Entidades;
using Release.Helper.Proxy;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys;

public class CapacitacionResultadoComandoProxy : BaseProxy
{
    private readonly string _url;

    public CapacitacionResultadoComandoProxy(AppConfig appConfig)
    {
        _url = string.Format("{0}CapacitacionResultadoComando/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
    }

    public async Task<StatusResponse<int>>
        InsertarCapacitacionResultado(CapacitacionResultadoRequest request)
    {
        return await InvokeWebApiAsync<StatusResponse<int>>(
            HttpMethod.Post,
            _url + "InsertarCapacitacionResultado",
            GetJsonParameters(request));
    }

    public async Task<StatusResponse<int>>
        ActualizarCapacitacionResultado(CapacitacionResultadoRequest request)
    {
        return await InvokeWebApiAsync<StatusResponse<int>>(
            HttpMethod.Put,
            _url + "ActualizarCapacitacionResultado",
            GetJsonParameters(request));
    }
}
