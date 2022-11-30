using Release.Helper;
using Release.Helper.Proxy;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys;

public class ResultadoConsultaProxy : BaseProxy
{
    private readonly string _url;

    public ResultadoConsultaProxy(AppConfig appConfig)
    {
        _url = string.Format("{0}ResultadoConsulta/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
    }

    public async Task<StatusResponse<IEnumerable<ResultadoResponse>>>
        ListarResultados(ResultadoRequest request)
    {
        return await InvokeWebApiAsync<StatusResponse<IEnumerable<ResultadoResponse>>>(
            HttpMethod.Get,
            _url + "ListarResultados",
            GetJsonParameters(request));
    }
    public async Task<StatusResponse<IEnumerable<ResultadoResponse>>>
        ListarResultadosHistorico(ResultadoRequest request)
    {
        return await InvokeWebApiAsync<StatusResponse<IEnumerable<ResultadoResponse>>>(
            HttpMethod.Get,
            _url + "ListarResultadosHistorico",
            GetJsonParameters(request));
    }
}
