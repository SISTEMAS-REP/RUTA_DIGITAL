using Release.Helper;
using Microsoft.AspNetCore.Mvc;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Controllers.Consultas;

[ApiController]
[Route("[controller]")]
public class CapacitacionConsultaController : ControllerBase
{
    private readonly ICapacitacionAplicacion _capacitacionAplicacion;

    public CapacitacionConsultaController(ICapacitacionAplicacion capacitacionAplicacion)
    {
        _capacitacionAplicacion = capacitacionAplicacion;
    }

    [HttpGet]
    [Route("ListarCapacitaciones")]
    public async Task<StatusResponse<IEnumerable<CapacitacionResponse>>> 
        ListarCapacitaciones(CapacitacionRequest request)
    {
        return await _capacitacionAplicacion
            .ListarCapacitaciones(request);
    }
}
