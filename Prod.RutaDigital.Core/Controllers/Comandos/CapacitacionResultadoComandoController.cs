using Release.Helper;
using Microsoft.AspNetCore.Mvc;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Controllers.Consultas;

[ApiController]
[Route("[controller]")]
public class CapacitacionResultadoComandoController : ControllerBase
{
    private readonly ICapacitacionResultadoAplicacion _capacitacionAplicacion;

    public CapacitacionResultadoComandoController(ICapacitacionResultadoAplicacion capacitacionAplicacion)
    {
        _capacitacionAplicacion = capacitacionAplicacion;
    }

    [HttpPost]
    [Route("InsertarCapacitacionResultado")]
    public async Task<StatusResponse<int>>
        InsertarCapacitacionResultado(CapacitacionResultadoRequest request)
    {
        return await _capacitacionAplicacion
            .InsertarCapacitacionResultado(request);
    }

    [HttpPut]
    [Route("ActualizarCapacitacionResultado")]
    public async Task<StatusResponse<int>>
        ActualizarCapacitacionResultado(CapacitacionResultadoRequest request)
    {
        return await _capacitacionAplicacion
            .ActualizarCapacitacionResultado(request);
    }
}
