using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prod.RutaDigital.Entidades;
using Prod.RutaDigital.Presentacion.Configuracion.Proxys;
using Release.Helper;
using System.Security.Claims;

namespace Prod.RutaDigital.Presentacion.Angular.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class AuthorizationController : ControllerBase
{
    private readonly IHttpContextAccessor? _httpContextAccessor;
    private readonly UsuarioExtranetConsultaProxy _usuarioExtranetConsultaProxy;

    public AuthorizationController(IHttpContextAccessor? httpContextAccessor, 
        UsuarioExtranetConsultaProxy usuarioExtranetConsultaProxy)
    {
        _httpContextAccessor = httpContextAccessor;
        _usuarioExtranetConsultaProxy = usuarioExtranetConsultaProxy;
    }

    [HttpGet]
    public async Task<IActionResult>
        Cookie()
    {
        var response = new StatusResponse<UsuarioExtranetResponse>();

        if (_httpContextAccessor is null
            || _httpContextAccessor.HttpContext is null
            || !_httpContextAccessor.HttpContext.User.Identity!.IsAuthenticated)
        {
            //response.StatusCode = StatusCodes.Status401Unauthorized;
            return new ObjectResult(response);
        }

        var httpContext = _httpContextAccessor.HttpContext;

        var idUsuarioExtranet = httpContext.User
            .FindFirstValue(ClaimTypes.NameIdentifier);

        var usuarioResponse = await _usuarioExtranetConsultaProxy
            .BuscarUsuario(new()
            {
                id_usuario_extranet = int.Parse(idUsuarioExtranet)
            });

        if (usuarioResponse is null
            || !usuarioResponse.Success
            || usuarioResponse.Data is null)
        {
            //response.StatusCode = StatusCodes.Status404NotFound;
            return new ObjectResult(response);
        }

        //response.StatusCode = StatusCodes.Status200OK;
        response.Success = true;
        response.Data = usuarioResponse.Data;

        return await Task.FromResult(Ok(response));
    }
}
