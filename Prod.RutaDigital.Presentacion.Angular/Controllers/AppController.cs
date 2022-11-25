﻿using Microsoft.AspNetCore.Mvc;
using Prod.RutaDigital.Presentacion.Configuracion;
using Release.Helper;

namespace Prod.RutaDigital.Presentacion.Angular.Controllers;

[ApiController]
[Route("[controller]")]
public class AppController : ControllerBase
{
    private readonly AppConfig _appConfig;
    private readonly AppVariables _appVariables;
    private readonly AppAuditoria _appAuditoria;

    public AppController(AppConfig appConfig,
        AppVariables appVariables,
        AppAuditoria appAuditoria)
    {
        _appConfig = appConfig;
        _appVariables = appVariables;
        _appAuditoria = appAuditoria;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<StatusResponse<ApplicationDataViewModel>> GetAppData()
    {
        var content = new Dictionary<string, string>
        {
            { "applicationId", _appAuditoria.IdAplicacion },
            { "applicationTitle", _appVariables.TituloAplicacion },
            { "applicationDescription", _appVariables.DescripcionAplicacion },
            { "loginUnicoWebPath", _appConfig.Urls.URL_LOGIN_UNICO_WEB }
        };

        var data = new ApplicationDataViewModel()
        {
            Content = content,
        };

        var result = new StatusResponse<ApplicationDataViewModel>()
        {
            Success = true,
            Data =data
        };

        return Ok(result);
    }
}
