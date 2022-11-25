using Release.Helper;
using Microsoft.AspNetCore.Mvc;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Controllers.Consultas;

[ApiController]
[Route("[controller]")]
public class CapacitacionComandoController : ControllerBase
{
    private readonly ICapacitacionAplicacion _capacitacionAplicacion;

    public CapacitacionComandoController(ICapacitacionAplicacion capacitacionAplicacion)
    {
        _capacitacionAplicacion = capacitacionAplicacion;
    }

    [HttpPost]
    [Route("InsertarCapacitacion")]
    public async Task<StatusResponse<int>>
        InsertarCapacitacion(CapacitacionRequest request)
    {
        return await _capacitacionAplicacion
            .InsertarCapacitacion(request);
    }
}
