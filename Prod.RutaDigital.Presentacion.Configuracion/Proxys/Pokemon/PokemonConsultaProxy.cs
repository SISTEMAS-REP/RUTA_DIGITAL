using Prod.RutaDigital.Entidades;
using Release.Helper;
using Release.Helper.Proxy;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys;

public class PokemonConsultaProxy : BaseProxy
{
    private readonly string _url;

    public PokemonConsultaProxy(AppConfig appConfig,
        IHttpClientFactory httpClientFactory)
        : base(httpClientFactory)
    {
        _url = string.Format("{0}PokemonConsulta/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
    }

    public Task<StatusResponse<List<PokemonResponse>>> Listar(PokemonRequest request)
    {
        return base.CallWebApiAsync<StatusResponse<List<PokemonResponse>>>(
                verb: HttpMethod.Get,
                urlAction: _url + "Listar",
                this.GetJsonParameters(request));
    }

}
