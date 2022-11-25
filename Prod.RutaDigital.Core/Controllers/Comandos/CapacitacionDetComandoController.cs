using Release.Helper;
using Microsoft.AspNetCore.Mvc;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Controllers.Consultas;

[ApiController]
[Route("[controller]")]
public class CapacitacionDetComandoController : ControllerBase
{
    private readonly ICapacitacionDetAplicacion _capacitacionDetAplicacion;

    public CapacitacionDetComandoController(ICapacitacionDetAplicacion capacitacionDetAplicacion)
    {
        _capacitacionDetAplicacion = capacitacionDetAplicacion;
    }

    [HttpPost]
    [Route("InsertarCapacitacionDet")]
    public async Task<StatusResponse<int>>
        InsertarCapacitacionDet(CapacitacionDetRequest request)
    {
        return await _capacitacionDetAplicacion
            .InsertarCapacitacionDet(request);
    }
}
