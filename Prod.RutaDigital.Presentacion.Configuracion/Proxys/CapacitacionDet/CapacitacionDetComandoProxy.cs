using Release.Helper;

using Prod.RutaDigital.Entidades;
using Release.Helper.Proxy;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys;

public class CapacitacionDetComandoProxy : BaseProxy
{
    private readonly string _url;

    public CapacitacionDetComandoProxy(AppConfig appConfig)
    {
        _url = string.Format("{0}CapacitacionDetComando/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
    }

    public async Task<StatusResponse<int>>
        InsertarCapacitacionDet(CapacitacionDetRequest request)
    {
        return await InvokeWebApiAsync<StatusResponse<int>>(
            HttpMethod.Post,
            _url + "InsertarCapacitacionDet",
            GetJsonParameters(request));
    }
}
