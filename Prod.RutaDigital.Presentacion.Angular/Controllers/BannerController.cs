using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prod.RutaDigital.Entidades;
using Prod.RutaDigital.Presentacion.Configuracion.Proxys;

namespace Prod.RutaDigital.Presentacion.Angular.Controllers;

[ApiController]
//[Authorize]
[Route("[controller]")]
public class BannerController : ControllerBase
{
    private readonly BannerConsultaProxy _bannerConsulta;
    private readonly EventoConsultaProxy _eventoConsultaProxy;
    private readonly PremioConsultaProxy _premioConsulta;
    public BannerController(BannerConsultaProxy bannerConsulta, EventoConsultaProxy eventoConsultaProxy, PremioConsultaProxy premioConsulta)
    {
        _bannerConsulta = bannerConsulta;
        _eventoConsultaProxy = eventoConsultaProxy;
        _premioConsulta = premioConsulta;
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
}
