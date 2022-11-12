using Release.Helper;
using Microsoft.AspNetCore.Mvc;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Controllers.Consultas;

[ApiController]
[Route("[controller]")]
public class TipoPremioConsultaController : ControllerBase
{
    private readonly ITipoPremioAplicacion _tipoPremioAplicacion;

    public TipoPremioConsultaController(ITipoPremioAplicacion tipoPremioAplicacion)
    {
        _tipoPremioAplicacion = tipoPremioAplicacion;
    }

    [HttpGet]
    [Route("ListarTiposPremio")]
    public async Task<StatusResponse<IEnumerable<TipoPremio>>>
        ListarTiposPremio()
    {
        return await _tipoPremioAplicacion
            .ListarTiposPremio();
    }
}
