using Release.Helper;
using Release.Helper.Proxy;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys;

public class PublicidadPieConsultaProxy : BaseProxy
{
    private readonly string _url;

    public PublicidadPieConsultaProxy(AppConfig appConfig)
    {
        _url = string.Format("{0}PublicidadPieConsulta/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
    }

    public async Task<StatusResponse<IEnumerable<PublicidadPie>>>
        ListarPublicidadPie()
    {
        return await InvokeWebApiAsync<StatusResponse<IEnumerable<PublicidadPie>>>(
            HttpMethod.Get, 
            _url + "ListarPublicidadPie", null);
    }
}
