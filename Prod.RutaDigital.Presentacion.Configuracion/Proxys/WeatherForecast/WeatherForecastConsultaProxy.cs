using Prod.RutaDigital.Entidades;
using Release.Helper;
using Release.Helper.ProxyV2;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys;

public class WeatherForecastConsultaProxy : BaseProxy
{
    private readonly string _url;

    public WeatherForecastConsultaProxy(AppConfig appConfig, 
        IHttpClientFactory httpClientFactory) 
        : base(httpClientFactory)
    {
        _url = string.Format("{0}WeatherForecastConsulta/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
    }

    public Task<StatusResponse<List<WeatherForecastResponse>>> Listar(WeatherForecastRequest request)
    {
        return CallWebApiAsync<StatusResponse<List<WeatherForecastResponse>>>(
                verb: HttpMethod.Get,
                urlAction: _url + "Listar",
                GetJsonParameters(request));
    }
}
