using Release.Helper;
using Microsoft.AspNetCore.Mvc;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Controllers.Consultas;

[ApiController]
[Route("[controller]")]
public class AvanceModuloConsultaController : ControllerBase
{
    private readonly IAvanceModuloAplicacion _avanceModuloAplicacion;

    public AvanceModuloConsultaController(IAvanceModuloAplicacion avanceModuloAplicacion)
    {
        _avanceModuloAplicacion = avanceModuloAplicacion;
    }

    [HttpGet]
    [Route("ListarAvancesModulos")]
    public async Task<StatusResponse<IEnumerable<AvanceModuloResponse>>>
        ListarAvancesModulos(AvanceModuloRequest request)
    {
        return await _avanceModuloAplicacion
            .ListarAvancesModulos(request);
    }
}
