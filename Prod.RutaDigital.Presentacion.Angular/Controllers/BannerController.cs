using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prod.RutaDigital.Entidades;
using Prod.RutaDigital.Presentacion.Configuracion.Proxys;
using Prod.RutaDigital.Presentacion.Configuracion.Proxys.Comun;

namespace Prod.RutaDigital.Presentacion.Angular.Controllers;

[ApiController]
//[Authorize]
[Route("[controller]")]
public class BannerController : ControllerBase
{
    private readonly BannerConsultaProxy _bannerConsulta;
    private readonly EventoConsultaProxy _eventoConsultaProxy;
    private readonly PremioConsultaProxy _premioConsulta;
    private readonly ComunConsultaProxy _comunConsulta;
    private readonly IConfiguration _configuration;
    public BannerController(BannerConsultaProxy bannerConsulta, EventoConsultaProxy eventoConsultaProxy, PremioConsultaProxy premioConsulta, IConfiguration configuration, ComunConsultaProxy comunConsulta)
    {
        _bannerConsulta = bannerConsulta;
        _eventoConsultaProxy = eventoConsultaProxy;
        _premioConsulta = premioConsulta;
        _configuration = configuration;
        _comunConsulta = comunConsulta;
    }

    [AllowAnonymous]
    [HttpGet("ListarBannerPrincipal")]
    public async Task<IActionResult> ListarBannerPrincipal()
    {
        var results = await _bannerConsulta.ListarBannerPrincipal();
        return Ok(results);
    }
    [AllowAnonymous]
    [HttpGet("ListarBannerPiePagina")]
    public async Task<IActionResult> ListarBannerPiePagina()
    {
        var results = await _bannerConsulta.ListarBannerPiePagina();
        return Ok(results);
    }
    [AllowAnonymous]
    [HttpGet("ListarEvento")]
    public async Task<IActionResult> ListarEvento([FromQuery] EventoRequest request)
    {
        var results = await _eventoConsultaProxy.ListarEventos(request);
        return Ok(results);
    }

    [AllowAnonymous]
    [HttpGet("ListarPublicidadPremio")]
    public async Task<IActionResult> ListarPublicidadPremio()
    {
        var results = await _premioConsulta.ListarPublicidadPremio();
        return Ok(results);
    }

    [AllowAnonymous]
    [HttpGet("ListarTipoPremio")]
    public async Task<IActionResult> ListarTipoPremio()
    {
        var results = await _premioConsulta.ListarTipoPremio();
        return Ok(results);
    }

    [AllowAnonymous]
    [HttpGet("ListarPremio")]
    public async Task<IActionResult> ListarPremio([FromQuery] PremioRequest request)
    {
        var results = await _premioConsulta.ListarPremio(request);
        return Ok(results);
    }

    [AllowAnonymous]
    [HttpGet("ListarNivelPremio")]
    public async Task<IActionResult> ListarNivelPremio()
    {
        var results = await _premioConsulta.ListarNivelPremio();
        return Ok(results);
    }

    [AllowAnonymous]
    [HttpGet("ListarPuntajePremio")]
    public async Task<IActionResult> ListarPuntajePremio()
    {
        var results = await _premioConsulta.ListarPuntajePremio();
        return Ok(results);
    }

    [AllowAnonymous]
    [HttpGet("RedireccionarLoginUnico")]
    public IActionResult RedireccionarLoginUnico([FromQuery] LoginUnico request)
    {
        string IdApp = this._configuration.GetSection("IdApp").Value;
        string urlLogin = this._configuration.GetSection("URL_LOGIN_UNICO").Value;

        string URL_LOGIN_UNICO_CORE_PERSON = this._configuration.GetSection("AppConfig:Urls:URL_LOGIN_UNICO_CORE_PERSON").Value;
        string URL_LOGIN_UNICO_CORE_COMPANY = this._configuration.GetSection("AppConfig:Urls:URL_LOGIN_UNICO_CORE_COMPANY").Value;
        string URL_LOGIN_UNICO_CORE_PROFILE = this._configuration.GetSection("AppConfig:Urls:URL_LOGIN_UNICO_CORE_PROFILE").Value;
        string URL_LOGIN_UNICO_CORE_LOGOUT = this._configuration.GetSection("AppConfig:Urls:URL_LOGIN_UNICO_CORE_LOGOUT").Value;

        var results = "";
        switch (request.id_tipo_url)
        {
            case 1:
                results = URL_LOGIN_UNICO_CORE_PERSON + "?applicationId=" + IdApp + "&returnUrl=" + urlLogin;
                Redirect(results);
                break;
            case 2:
                results = URL_LOGIN_UNICO_CORE_COMPANY + "?applicationId=" + IdApp + "&returnUrl=" + urlLogin;
                Redirect(results);
                break;
            case 3:
                results = URL_LOGIN_UNICO_CORE_PROFILE + "?applicationId=" + IdApp + "&returnUrl=" + urlLogin;
                Redirect(results);
                break;
            case 4:
                results = URL_LOGIN_UNICO_CORE_LOGOUT + "?applicationId=" + IdApp + "&returnUrl=" + urlLogin;
                Redirect(results);
                break;
            default:
                results = "Error";
                break;
        }

        return Ok(new 
        {
            Succeeded = true,
            Value = results
        });
    }


    [AllowAnonymous]
    [HttpGet("VerificarAutoDiagnosticoHistorico")]
    public IActionResult VerificarAutoDiagnosticoHistorico([FromQuery] LoginUnicoRequest request)
    {
        var results = _comunConsulta.VerificarAutoDiagnosticoHistorico(request);
        return Ok(results);
    }

    [AllowAnonymous]
    [HttpGet("VerificarAutoDiagnostico")]
    public IActionResult VerificarAutoDiagnostico([FromQuery] LoginUnicoRequest request)
    {
        var results = _comunConsulta.VerificarAutoDiagnostico(request);
        return Ok(results);
    }
}
