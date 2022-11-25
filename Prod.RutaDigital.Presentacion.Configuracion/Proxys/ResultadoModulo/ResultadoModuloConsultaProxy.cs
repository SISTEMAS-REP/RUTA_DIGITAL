using Release.Helper;
using Release.Helper.Proxy;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys;

public class ResultadoModuloConsultaProxy : BaseProxy
{
    private readonly string _url;

    public ResultadoModuloConsultaProxy(AppConfig appConfig)
    {
        _url = string.Format("{0}ResultadoModuloConsulta/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
    }

    public async Task<StatusResponse<IEnumerable<ResultadoModuloResponse>>>
        ListarResultadoModulos(ResultadoModuloRequest request)
    {
        return await InvokeWebApiAsync<StatusResponse<IEnumerable<ResultadoModuloResponse>>>(
            HttpMethod.Get,
            _url + "ListarResultadoModulos",
            GetJsonParameters(request));
    }
}
