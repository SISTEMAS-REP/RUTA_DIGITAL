using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prod.RutaDigital.Entidades;
using Release.Helper;
using System.Security.Claims;

namespace Prod.RutaDigital.Presentacion.Angular.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class AuthorizationController : ControllerBase
{
    private readonly IHttpContextAccessor? _httpContextAccessor;

    public AuthorizationController(IHttpContextAccessor? httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpGet]
    public async Task<IActionResult>
        Cookie()
    {
        var response = new StatusResponse<UsuarioExtranet>();
        
        if (_httpContextAccessor is null 
            || _httpContextAccessor.HttpContext is null
            || !_httpContextAccessor.HttpContext.User.Identity!.IsAuthenticated)
        {
            response.StatusCode = HttpStatusCodes.Status401Unauthorized;
            return new ObjectResult(response);
        }

        var httpContext = _httpContextAccessor.HttpContext;

        var userId = httpContext.User
            .FindFirstValue(ClaimTypes.NameIdentifier);

        var userName = httpContext.User
            .FindFirstValue(ClaimTypes.Name);

        var email = httpContext?.User
                .FindFirstValue(ClaimTypes.Email);

        var data = new UsuarioExtranet()
        {
            id_usuario_extranet = int.Parse(userId),
            user_name = userName,
            email = email
        };

        response.StatusCode = HttpStatusCodes.Status200OK;
        response.Success = true;
        response.Data = data;

        return await Task.FromResult(Ok(response));
    }
}
