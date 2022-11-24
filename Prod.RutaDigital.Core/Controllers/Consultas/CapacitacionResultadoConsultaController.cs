using Release.Helper;
using Microsoft.AspNetCore.Mvc;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Controllers.Consultas;

[ApiController]
[Route("[controller]")]
public class CapacitacionResultadoConsultaController : ControllerBase
{
    private readonly ICapacitacionResultadoAplicacion _capacitacionAplicacion;

    public CapacitacionResultadoConsultaController(ICapacitacionResultadoAplicacion capacitacionAplicacion)
    {
        _capacitacionAplicacion = capacitacionAplicacion;
    }

    [HttpGet]
    [Route("ListarCapacitacionesResultado")]
    public async Task<StatusResponse<IEnumerable<CapacitacionResultadoResponse>>>
        ListarCapacitacionesResultado(CapacitacionResultadoRequest request)
    {
        return await _capacitacionAplicacion
            .ListarCapacitacionesResultado(request);
    }
}
