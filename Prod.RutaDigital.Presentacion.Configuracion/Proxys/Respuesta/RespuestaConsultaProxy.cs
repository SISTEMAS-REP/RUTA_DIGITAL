using Release.Helper;
using Release.Helper.Proxy;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys;

public class RespuestaConsultaProxy : BaseProxy
{
    private readonly string _url;

    public RespuestaConsultaProxy(AppConfig appConfig)
    {
        _url = string.Format("{0}RespuestaConsulta/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
    }

    public async Task<StatusResponse<IEnumerable<RespuestaResponse>>>
        ListarRespuestas(RespuestaRequest request)
    {
        return await InvokeWebApiAsync<StatusResponse<IEnumerable<RespuestaResponse>>>(
            HttpMethod.Get,
            _url + "ListarRespuestas",
            GetJsonParameters(request));
    }
}
