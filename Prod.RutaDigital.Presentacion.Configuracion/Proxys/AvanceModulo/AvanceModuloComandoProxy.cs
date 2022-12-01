using Release.Helper;

using Prod.RutaDigital.Entidades;
using Release.Helper.Proxy;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys;

public class AvanceModuloComandoProxy : BaseProxy
{
    private readonly string _url;

    public AvanceModuloComandoProxy(AppConfig appConfig)
    {
        _url = string.Format("{0}AvanceModuloComando/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
    }

    public async Task<StatusResponse<int>>
        InsertarAvanceModulo(AvanceModuloRequest request)
    {
        return await InvokeWebApiAsync<StatusResponse<int>>(
            HttpMethod.Post,
            _url + "InsertarAvanceModulo",
            GetJsonParameters(request));
    }
}
