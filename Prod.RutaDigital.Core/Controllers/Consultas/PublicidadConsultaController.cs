using Release.Helper;
using Microsoft.AspNetCore.Mvc;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Controllers.Consultas;

[ApiController]
[Route("[controller]")]
public class PublicidadConsultaController : ControllerBase
{
    private readonly IPublicidadAplicacion _publicidadAplicacion;

    public PublicidadConsultaController(IPublicidadAplicacion publicidadAplicacion)
    {
        _publicidadAplicacion = publicidadAplicacion;
    }

    [HttpGet]
    [Route("ListarPublicidad")]
    public async Task<StatusResponse<IEnumerable<Publicidad>>>
        ListarPublicidad()
    {
        return await _publicidadAplicacion
            .ListarPublicidad();
    }
}
