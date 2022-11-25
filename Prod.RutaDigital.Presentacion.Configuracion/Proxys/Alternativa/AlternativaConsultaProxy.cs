using Release.Helper;

using Prod.RutaDigital.Entidades;
using Release.Helper.Proxy;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys;

public class AlternativaConsultaProxy : BaseProxy
{
    private readonly string _url;

    public AlternativaConsultaProxy(AppConfig appConfig)
    {
        _url = string.Format("{0}AlternativaConsulta/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
    }

    public async Task<StatusResponse<IEnumerable<AlternativaResponse>>>
        ListarAlternativas(AlternativaRequest request)
    {
        return await InvokeWebApiAsync<StatusResponse<IEnumerable<AlternativaResponse>>>(
            HttpMethod.Get,
            _url + "ListarAlternativas",
            GetJsonParameters(request));
    }
}
