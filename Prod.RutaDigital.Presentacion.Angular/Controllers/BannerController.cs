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
    public BannerController(BannerConsultaProxy bannerConsulta, EventoConsultaProxy eventoConsultaProxy)
    {
        _bannerConsulta = bannerConsulta;
        _eventoConsultaProxy = eventoConsultaProxy;
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
}
