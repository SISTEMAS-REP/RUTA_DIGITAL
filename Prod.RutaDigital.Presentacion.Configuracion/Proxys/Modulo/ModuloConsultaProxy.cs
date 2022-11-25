using Release.Helper;
using Release.Helper.Proxy;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys;

public class ModuloConsultaProxy : BaseProxy
{
    private readonly string _url;

    public ModuloConsultaProxy(AppConfig appConfig)
    {
        _url = string.Format("{0}ModuloConsulta/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
    }

    public async Task<StatusResponse<IEnumerable<ModuloResponse>>>
        ListarModulos(ModuloRequest request)
    {
        return await InvokeWebApiAsync<StatusResponse<IEnumerable<ModuloResponse>>>(
            HttpMethod.Get,
            _url + "ListarModulos",
            GetJsonParameters(request));
    }
}
