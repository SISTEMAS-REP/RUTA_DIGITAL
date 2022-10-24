﻿using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Release.Helper;

namespace Prod.RutaDigital.Presentacion.Angular.Controllers;

[ApiController]
[Route("[controller]")]
public class AppController : Controller
{
    private readonly IHttpContextAccessor _contextAccessor;

    public AppController(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
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
        content.Add("loginUnicoApiPath", "https://localhost:7086/");
        content.Add("loginUnicoWebPath", "https://localhost:44428/");

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
