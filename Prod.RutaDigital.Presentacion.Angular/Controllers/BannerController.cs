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
    public BannerController(BannerConsultaProxy bannerConsulta)
    {
        _bannerConsulta = bannerConsulta;
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
        return Ok(new JsonResult(results));
    }
}
