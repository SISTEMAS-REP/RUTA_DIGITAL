﻿using Release.Helper;
using Release.Helper.Proxy;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Presentacion.Configuracion.Proxys;

public class CapacitacionConsultaProxy : BaseProxy
{
    private readonly string _url;

    public CapacitacionConsultaProxy(AppConfig appConfig)
    {
        _url = string.Format("{0}CapacitacionConsulta/", appConfig.Urls.URL_RUTA_DIGITAL_CORE_API);
    }

    public async Task<StatusResponse<IEnumerable<CapacitacionResponse>>>
        ListarCapacitaciones(CapacitacionRequest request)
    {
        return await InvokeWebApiAsync<StatusResponse<IEnumerable<CapacitacionResponse>>>(
            HttpMethod.Get,
            _url + "ListarCapacitaciones",
            GetJsonParameters(request));
    }
}
