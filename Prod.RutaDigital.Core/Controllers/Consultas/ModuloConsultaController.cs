using Release.Helper;
using Microsoft.AspNetCore.Mvc;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Controllers.Consultas;

[ApiController]
[Route("[controller]")]
public class ModuloConsultaController : ControllerBase
{
    private readonly IModuloAplicacion _moduloAplicacion;

    public ModuloConsultaController(IModuloAplicacion moduloAplicacion)
    {
        _moduloAplicacion = moduloAplicacion;
    }

    [HttpGet]
    [Route("ListarModulos")]
    public async Task<StatusResponse<IEnumerable<ModuloResponse>>> 
        ListarModulos(ModuloRequest request)
    {
        return await _moduloAplicacion
            .ListarModulos(request);
    }
}
