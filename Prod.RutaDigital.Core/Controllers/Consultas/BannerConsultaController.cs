using Microsoft.AspNetCore.Mvc;
using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Entidades;
using Release.Helper;

namespace Prod.RutaDigital.Core.Controllers.Consultas;

[ApiController]
[Route("[controller]")]
public class BannerConsultaController : ControllerBase
{
    private readonly IBannerAplicacion _bannerAplicacion;

    public BannerConsultaController(IBannerAplicacion bannerAplicacion)
    {
        _bannerAplicacion = bannerAplicacion;
    }

    [HttpGet]
    [Route("ListarBannerPrincipal")]
    public async Task<StatusResponse<List<BannerResponse>>> ListarBannerPrincipal()
    {
        return await _bannerAplicacion
            .ListarBannerPrincipal();
    }

    [HttpGet]
    [Route("ListarBannerPiePagina")]
    public async Task<StatusResponse<List<BannerResponse>>> ListarBannerPiePagina()
    {
        return await _bannerAplicacion
            .ListarBannerPiePagina();
    }
}