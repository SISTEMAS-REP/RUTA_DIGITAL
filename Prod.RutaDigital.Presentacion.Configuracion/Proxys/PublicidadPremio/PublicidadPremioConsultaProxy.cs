using Release.Helper;
using Release.Helper.Proxy;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys;

public class PublicidadPremioConsultaProxy : BaseProxy
{
    private readonly string _url;

    public PublicidadPremioConsultaProxy(AppConfig appConfig)
    {
        _url = string.Format("{0}PublicidadPremioConsulta/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
    }

    public async Task<StatusResponse<IEnumerable<PublicidadPremio>>>
        ListarPublicidadPremio()
    {
        return await InvokeWebApiAsync<StatusResponse<IEnumerable<PublicidadPremio>>>(
            HttpMethod.Get, 
            _url + "ListarPublicidadPremio", null);
    }
}
