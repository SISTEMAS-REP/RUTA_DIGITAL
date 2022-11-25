using Release.Helper;
using Release.Helper.Proxy;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys;

public class EvaluacionComandoProxy : BaseProxy
{
    private readonly string _url;

    public EvaluacionComandoProxy(AppConfig appConfig)
    {
        _url = string.Format("{0}EvaluacionComando/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
    }

    public async Task<StatusResponse<int>>
        InsertarEvaluacion(EvaluacionRequest request)
    {
        return await InvokeWebApiAsync<StatusResponse<int>>(
            HttpMethod.Post,
            _url + "InsertarEvaluacion",
            GetJsonParameters(request));
    }

    public async Task<StatusResponse<int>>
        ActualizarEvaluacion(EvaluacionRequest request)
    {
        return await InvokeWebApiAsync<StatusResponse<int>>(
            HttpMethod.Put,
            _url + "ActualizarEvaluacion",
            GetJsonParameters(request));
    }
}
