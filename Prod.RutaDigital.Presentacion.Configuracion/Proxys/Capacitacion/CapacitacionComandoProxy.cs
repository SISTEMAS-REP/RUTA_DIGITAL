using Release.Helper;

using Prod.RutaDigital.Entidades;
using Release.Helper.Proxy;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys;

public class CapacitacionComandoProxy : BaseProxy
{
    private readonly string _url;

    public CapacitacionComandoProxy(AppConfig appConfig)
    {
        _url = string.Format("{0}CapacitacionComando/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
    }

    public async Task<StatusResponse<int>>
        InsertarCapacitacion(CapacitacionRequest request)
    {
        return await InvokeWebApiAsync<StatusResponse<int>>(
            HttpMethod.Post,
            _url + "InsertarCapacitacion",
            GetJsonParameters(request));
    }
}
