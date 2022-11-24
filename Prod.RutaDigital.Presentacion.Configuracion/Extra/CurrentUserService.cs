using System.Net.Sockets;
using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Prod.RutaDigital.Presentacion.Configuracion;

namespace Prod.LoginUnico.Presentacion.Configuracion.Extra;

public class CurrentUserService
{
    private readonly IHttpContextAccessor? _httpContextAccessor;
    private readonly ILogger<CurrentUserService> _logger;
    private readonly AppAuditoria _appAuditoria;
    private readonly AppVariables _appVariables;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor,
        ILogger<CurrentUserService> logger,
        AppAuditoria appAuditoria,
        AppVariables appVariables)
    {
        _httpContextAccessor = httpContextAccessor;
        _logger = logger;
        _appAuditoria = appAuditoria;
        _appVariables = appVariables;

        // App is probably initializing.
        if (_httpContextAccessor is null || _httpContextAccessor.HttpContext is null)
        {
            User = new CurrentUser(IdUsuarioExtranet: 0.ToString(),
                                   UserName: string.Empty,
                                   Email: string.Empty,

                                   DireccionIpRemota: string.Empty,
                                   IdAplicacion: 0.ToString(),
                                   NombreDispositivo: string.Empty,

                                   Autenticado: false);
            return;
        }

        var httpContext = _httpContextAccessor.HttpContext;
        var autenticado = httpContext!.User.Identity!.IsAuthenticated;

        var userId = httpContext?.User?
            .FindFirstValue(ClaimTypes.NameIdentifier)
            ?? 0.ToString();

        var userName = httpContext?.User?
                .FindFirstValue(ClaimTypes.Name)
                ?? _appAuditoria.Usuario;

        var email = httpContext?.User?
                .FindFirstValue(ClaimTypes.Email)
                ?? string.Empty;

        var direccionIpRemota = httpContext?.Request.Headers["X-Forwarded-For"]
            .ToString() ?? string.Empty;
        if (string.IsNullOrEmpty(direccionIpRemota))
        {
            direccionIpRemota = Dns.GetHostEntry(Dns.GetHostName())
                .AddressList
                .Where(a => a.AddressFamily == AddressFamily.InterNetwork)
                .Select(w => w.ToString())
                .First() ?? string.Empty;
        }

        var idAplicacion = httpContext?.Request.Headers["X-Application-Id"]
            .ToString() ?? _appAuditoria.IdAplicacion;

        var nombreDispositivo = string.Empty;
        var ipAddress = httpContext?.Connection.RemoteIpAddress;
        if (ipAddress is not null)
        {
            try
            {
                var hostEntry = Dns.GetHostEntryAsync(direccionIpRemota);
                nombreDispositivo = hostEntry.IsCompleted && !hostEntry.IsFaulted
                    ? hostEntry.Result.HostName
                    : string.Empty;
            }
            catch (Exception ex)
            {
                nombreDispositivo = string.Empty;
                _logger.LogError(ex, "[HttpContext.Connection: {@Connection}] " +
                    "[remoteIpAddress: {@remoteIpAddress}]",
                    httpContext?.Connection,
                    direccionIpRemota);
            }
        }

        User = new CurrentUser(IdUsuarioExtranet: userId,
                               UserName: userName,
                               Email: email,

                               DireccionIpRemota: direccionIpRemota,
                               IdAplicacion: idAplicacion,
                               NombreDispositivo: nombreDispositivo,

                               Autenticado: autenticado);
    }

    public CurrentUser User { get; }
}

public record CurrentUser(string IdUsuarioExtranet,
                          string UserName,
                          string Email,

                          string DireccionIpRemota,
                          string IdAplicacion,
                          string NombreDispositivo,

                          bool Autenticado);