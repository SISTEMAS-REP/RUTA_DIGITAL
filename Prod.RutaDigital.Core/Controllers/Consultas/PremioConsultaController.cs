using Release.Helper;
using Microsoft.AspNetCore.Mvc;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Controllers.Consultas;

[ApiController]
[Route("[controller]")]
public class PremioConsultaController : ControllerBase
{
    private readonly IPremioAplicacion _premioAplicacion;

    public PremioConsultaController(IPremioAplicacion premioAplicacion)
    {
        _premioAplicacion = premioAplicacion;
    }

    [HttpGet]
    [Route("ListarPremios")]
    public async Task<StatusResponse<IEnumerable<PremioResponse>>>
        ListarPremios(PremioRequest request)
    {
        return await _premioAplicacion
            .ListarPremios(request);
    }

    [HttpGet]
    [Route("ListarPuntajesPremios")]
    public async Task<StatusResponse<IEnumerable<Premio>>>
        ListarPuntajesPremios()
    {
        return await _premioAplicacion
            .ListarPuntajesPremios();
    }
}
