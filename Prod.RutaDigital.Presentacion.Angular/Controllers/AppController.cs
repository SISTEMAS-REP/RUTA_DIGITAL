using Microsoft.AspNetCore.Mvc;
using Prod.RutaDigital.Presentacion.Configuracion;
using Release.Helper;

namespace Prod.RutaDigital.Presentacion.Angular.Controllers;

[ApiController]
[Route("[controller]")]
public class AppController : ControllerBase
{
    private readonly AppConfig _appConfig;
    private readonly AppVariables _appVariables;

    public AppController(AppConfig appConfig, 
        AppVariables appVariables)
    {
        _appConfig = appConfig;
        _appVariables = appVariables;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<StatusResponse<ApplicationDataViewModel>> GetAppData()
    {
        var content = new Dictionary<string, string>
        {
            { "applicationId", _appVariables.IdAplicacion },
            { "applicationTitle", _appVariables.TituloAplicacion },
            { "applicationDescription", _appVariables.DescripcionAplicacion },
            { "loginUnicoWebPath", _appConfig.Urls.URL_LOGIN_UNICO_WEB }
        };

        var data = new ApplicationDataViewModel()
        {
            Content = content,
        };

        return Ok(new StatusResponse()
        {
            Success = true,
            Data = data
        });
    }
}
