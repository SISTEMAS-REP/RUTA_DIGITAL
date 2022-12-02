using Release.Helper;
using Microsoft.AspNetCore.Mvc;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Controllers.Consultas;

[ApiController]
[Route("[controller]")]
public class AvanceModuloComandoController : ControllerBase
{
    private readonly IAvanceModuloAplicacion _avanceModuloAplicacion;

    public AvanceModuloComandoController(IAvanceModuloAplicacion avanceModuloAplicacion)
    {
        _avanceModuloAplicacion = avanceModuloAplicacion;
    }

    [HttpPost]
    [Route("InsertarAvanceModulo")]
    public async Task<StatusResponse<int>>
        InsertarAvanceModulo(AvanceModuloRequest request)
    {
        return await _avanceModuloAplicacion
            .InsertarAvanceModulo(request);
    }
}
