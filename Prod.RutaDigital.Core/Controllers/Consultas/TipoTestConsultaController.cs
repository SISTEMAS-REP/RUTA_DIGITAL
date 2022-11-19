using Release.Helper;
using Microsoft.AspNetCore.Mvc;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Controllers.Consultas;

[ApiController]
[Route("[controller]")]
public class TipoTestConsultaController : ControllerBase
{
    private readonly ITipoTestAplicacion _tipoTestAplicacion;

    public TipoTestConsultaController(ITipoTestAplicacion tipoTestAplicacion)
    {
        _tipoTestAplicacion = tipoTestAplicacion;
    }

    [HttpGet]
    [Route("ListarTiposTest")]
    public async Task<StatusResponse<IEnumerable<TipoTestResponse>>> 
        ListarTiposTest(TipoTestRequest request)
    {
        return await _tipoTestAplicacion
            .ListarTiposTest(request);
    }
}
