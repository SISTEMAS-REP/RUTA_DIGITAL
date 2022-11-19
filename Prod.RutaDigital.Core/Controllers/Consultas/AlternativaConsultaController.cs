using Release.Helper;
using Microsoft.AspNetCore.Mvc;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Controllers.Consultas;

[ApiController]
[Route("[controller]")]
public class AlternativaConsultaController : ControllerBase
{
    private readonly IAlternativaAplicacion _alternativaAplicacion;

    public AlternativaConsultaController(IAlternativaAplicacion alternativaAplicacion)
    {
        _alternativaAplicacion = alternativaAplicacion;
    }

    [HttpGet]
    [Route("ListarAlternativas")]
    public async Task<StatusResponse<IEnumerable<AlternativaResponse>>> 
        ListarAlternativas(AlternativaRequest request)
    {
        return await _alternativaAplicacion
            .ListarAlternativas(request);
    }
}
