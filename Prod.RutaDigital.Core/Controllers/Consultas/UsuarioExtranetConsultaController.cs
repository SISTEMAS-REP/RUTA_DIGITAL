using Release.Helper;
using Microsoft.AspNetCore.Mvc;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Controllers.Consultas;

[ApiController]
[Route("[controller]")]
public class UsuarioExtranetConsultaController : ControllerBase
{
    private readonly IUsuarioExtranetAplicacion _usuarioExtranetAplicacion;

    public UsuarioExtranetConsultaController(IUsuarioExtranetAplicacion usuarioExtranetAplicacion)
    {
        _usuarioExtranetAplicacion = usuarioExtranetAplicacion;
    }

    [HttpGet]
    [Route("BuscarUsuario")]
    public async Task<StatusResponse<UsuarioExtranetResponse>>
        BuscarUsuario(UsuarioExtranetRequest request)
    {
        return await _usuarioExtranetAplicacion
            .BuscarUsuario(request);
    }
}
