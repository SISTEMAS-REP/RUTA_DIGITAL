using Release.Helper;
using Microsoft.AspNetCore.Mvc;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Controllers.Consultas;

[ApiController]
[Route("[controller]")]
public class PublicidadPieConsultaController : ControllerBase
{
    private readonly IPublicidadPieAplicacion _publicidadPieAplicacion;

    public PublicidadPieConsultaController(IPublicidadPieAplicacion publicidadPieAplicacion)
    {
        _publicidadPieAplicacion = publicidadPieAplicacion;
    }

    [HttpGet]
    [Route("ListarPublicidadPie")]
    public async Task<StatusResponse<IEnumerable<PublicidadPie>>>
        ListarPublicidadPie()
    {
        return await _publicidadPieAplicacion
            .ListarPublicidadPie();
    }
}
