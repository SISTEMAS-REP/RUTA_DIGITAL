using Release.Helper;
using Microsoft.AspNetCore.Mvc;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Controllers.Consultas;

[ApiController]
[Route("[controller]")]
public class PublicidadPremioConsultaController : ControllerBase
{
    private readonly IPublicidadPremioAplicacion _publicidadPremioAplicacion;

    public PublicidadPremioConsultaController(IPublicidadPremioAplicacion publicidadPremioAplicacion)
    {
        _publicidadPremioAplicacion = publicidadPremioAplicacion;
    }

    [HttpGet]
    [Route("ListarPublicidadPremio")]
    public async Task<StatusResponse<IEnumerable<PublicidadPremio>>>
        ListarPublicidadPremio()
    {
        return await _publicidadPremioAplicacion
            .ListarPublicidadPremio();
    }
}
