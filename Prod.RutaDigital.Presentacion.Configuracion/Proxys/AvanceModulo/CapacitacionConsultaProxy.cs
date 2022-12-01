using Release.Helper;
using Release.Helper.Proxy;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys;

public class AvanceModuloConsultaProxy : BaseProxy
{
    private readonly string _url;

    public AvanceModuloConsultaProxy(AppConfig appConfig)
    {
        _url = string.Format("{0}AvanceModuloConsulta/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
    }

    public async Task<StatusResponse<IEnumerable<AvanceModuloResponse>>>
        ListarAvancesModulos(AvanceModuloRequest request)
    {
        return await InvokeWebApiAsync<StatusResponse<IEnumerable<AvanceModuloResponse>>>(
            HttpMethod.Get,
            _url + "ListarAvancesModulos",
            GetJsonParameters(request));
    }
}
