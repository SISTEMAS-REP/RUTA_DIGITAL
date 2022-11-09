using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Prod.RutaDigital.Presentacion.Configuracion;
using Release.Helper;

namespace Prod.RutaDigital.Presentacion.Angular.Controllers;

[ApiController]
[Route("[controller]")]
public class AppController : Controller
{
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly AppConfig _appConfig;

    public AppController(IHttpContextAccessor contextAccessor, AppConfig appConfig)
    {
        _contextAccessor = contextAccessor;
        _appConfig = appConfig;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<StatusResponse<ApplicationDataViewModel>> GetAppData()
    {
        var applicationData = new ApplicationDataViewModel()
        {
            Content = GetContent(),
            CookieConsent = GetCookieConsent(),
        };

        return Ok(new StatusResponse()
        {
            Success = true,
            Data = applicationData
        });
    }

    private Dictionary<string, string> GetContent()
    {
        var content = new Dictionary<string, string>();
        content.Add("applicationId", "97");
        content.Add("applicationTitle", "Ruta Digital");
        content.Add("applicationDescription", "Ruta Digital V2");
        content.Add("loginUnicoWebPath", _appConfig.Urls.URL_LOGIN_UNICO_WEB);

        return content;
    }

    private object GetCookieConsent()
    {
        var consentFeature = _contextAccessor.HttpContext.Features.Get<ITrackingConsentFeature>();
        var showConsent = !consentFeature?.CanTrack ?? false;
        var cookieString = consentFeature?.CreateConsentCookie();
        return new { showConsent, cookieString };
    }
}
