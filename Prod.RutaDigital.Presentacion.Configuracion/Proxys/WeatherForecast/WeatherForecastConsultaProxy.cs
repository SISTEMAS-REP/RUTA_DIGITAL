using Release.Helper;
using Release.Helper.Proxy;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys;

public class WeatherForecastConsultaProxy : BaseProxy
{
    private readonly string _url;

    public WeatherForecastConsultaProxy(AppConfig appConfig)
    {
        _url = string.Format("{0}WeatherForecastConsulta/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
    }

    public async Task<StatusResponse<List<WeatherForecastResponse>>>
        ListarWeatherForecast(WeatherForecastRequest request)
    {
        return await InvokeWebApiAsync<StatusResponse<List<WeatherForecastResponse>>>(
                verb: HttpMethod.Get,
                urlAction: _url + "ListarWeatherForecast",
                GetJsonParameters(request));
    }
}
