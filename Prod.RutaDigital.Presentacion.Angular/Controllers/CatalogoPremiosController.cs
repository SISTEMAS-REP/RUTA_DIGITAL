using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Prod.RutaDigital.Entidades;
using Prod.RutaDigital.Presentacion.Configuracion;
using Prod.RutaDigital.Presentacion.Configuracion.Proxys;
using Prod.ServiciosExternos;
using Release.Helper;
using System.Web;

namespace Prod.RutaDigital.Presentacion.Angular.Controllers;

[AllowAnonymous]
[ApiController]
[Route("[controller]")]
public class CatalogoPremiosController : ControllerBase
{
    private readonly PublicidadPremioConsultaProxy _publicidadPremioConsultaProxy;
    private readonly PremioConsultaProxy _premioConsultaProxy;
    private readonly PremioComandoProxy _premioComandoProxy;
    private readonly TipoPremioConsultaProxy _tipoPremioConsultaProxy;
    private readonly NivelMadurezConsultaProxy _nivelMadurezConsultaProxy;
    private readonly AppVariables _appVariables;
    private readonly AppAuditoria _appAuditoria;
    private readonly IEmailSender _emailSender;
    public CatalogoPremiosController(PublicidadPremioConsultaProxy publicidadPremioConsultaProxy,
        PremioConsultaProxy premioConsultaProxy,
        PremioComandoProxy premioComandoProxy,
        TipoPremioConsultaProxy tipoPremioConsultaProxy,
        NivelMadurezConsultaProxy nivelMadurezConsultaProxy,
        AppVariables appVariables,
        AppAuditoria appAuditoria,
        IEmailSender emailSender)
    {
        _publicidadPremioConsultaProxy = publicidadPremioConsultaProxy;
        _premioConsultaProxy = premioConsultaProxy;
        _premioComandoProxy = premioComandoProxy;
        _tipoPremioConsultaProxy = tipoPremioConsultaProxy;
        _nivelMadurezConsultaProxy = nivelMadurezConsultaProxy;
        _appVariables = appVariables;
        _appAuditoria = appAuditoria;
        _emailSender = emailSender;
    }

    [HttpGet("ListarPublicidadPremio")]
    public async Task<IActionResult>
        ListarPublicidadPremio()
    {
        var response = await _publicidadPremioConsultaProxy
            .ListarPublicidadPremio();

        var data = response.Data
            .Select(s =>
            {
                var imagenPath = Path.Combine(_appVariables.RutaArchivos, s.imagen!);
                byte[]? numArray;

                try
                {
                    numArray = System.IO.File.ReadAllBytes(imagenPath);
                }
                catch
                {
                    numArray = null;
                }

                return new PublicidadPremioResponse()
                {
                    id_publicidad_premio = s.id_publicidad_premio,
                    imagen = s.imagen,
                    numArray = numArray
                };
            });

        var result = new StatusResponse<IEnumerable<PublicidadPremioResponse>>()
        {
            Success = true,
            Data = data
        };

        return Ok(result);
    }

    [HttpGet("ListarTipoPremio")]
    public async Task<IActionResult>
        ListarTiposPremio()
    {
        var response = await _tipoPremioConsultaProxy
            .ListarTiposPremio();

        var data = response.Data
            .Select(s =>
            {
                var imagenPath = Path.Combine(_appVariables.RutaArchivos, s.imagen!);
                byte[]? numArray;

                try
                {
                    numArray = System.IO.File.ReadAllBytes(imagenPath);
                }
                catch
                {
                    numArray = null;
                }

                return new TipoPremioResponse()
                {
                    id_tipo_premio = s.id_tipo_premio,
                    descripcion = s.descripcion,
                    imagen = s.imagen,
                    estado = s.estado,
                    numArray = numArray
                };
            });

        var result = new StatusResponse<IEnumerable<TipoPremioResponse>>()
        {
            Success = true,
            Data = data
        };

        return Ok(result);
    }

    [HttpGet("ListarPremio")]
    public async Task<IActionResult>
        ListarPremios([FromQuery] PremioRequest request)
    {
        var response = await _premioConsultaProxy
            .ListarPremios(request);

        var data = response.Data
            .Select(s =>
            {
                var fotoPath = Path.Combine(_appVariables.RutaArchivos, s.foto!);
                byte[]? numArray;

                try
                {
                    numArray = System.IO.File.ReadAllBytes(fotoPath);
                }
                catch
                {
                    numArray = null;
                }

                s.numArray = numArray;

                var fotoTipoPath = Path.Combine(_appVariables.RutaArchivos, s.foto_tipo!);
                byte[]? fotoTipoArray;

                try
                {
                    fotoTipoArray = System.IO.File.ReadAllBytes(fotoTipoPath);
                }
                catch
                {
                    fotoTipoArray = null;
                }

                s.fotoTipoArray = fotoTipoArray;

                return s;
            });

        var result = new StatusResponse<IEnumerable<PremioResponse>>()
        {
            Success = true,
            Data = data
        };

        return Ok(result);
    }

    [HttpGet("ListarNivelPremio")]
    public async Task<IActionResult>
        ListarNivelPremio()
    {
        var result = await _nivelMadurezConsultaProxy
            .ListarNivelesMadurez();
        return Ok(result);
    }

    [HttpGet("ListarPuntajePremio")]
    public async Task<IActionResult>
        ListarPuntajesPremios()
    {
        var result = await _premioConsultaProxy
            .ListarPuntajesPremios();
        return Ok(result);
    }

    [HttpGet("CanjePremio")]
    public async Task<IActionResult>
        CanjePremio([FromQuery] PremioCanjeRequest requests)
    {
        requests.usuario_registro = _appAuditoria.Usuario;
        var result = await _premioComandoProxy
            .CanjePremio(requests);

        if (result.Success)
        {
            var data = new
            {
                cantidad = requests.cantidad,
                nombre = _appAuditoria.Usuario,
                descripcion_premio = requests.descripcion_premio,
                nombre_premio = requests.nombre_premio
            };

            await _emailSender.SendAsync(templateName: "CanjePremio",
               request: new()
               {
                   to = result.Data.email,
                   isBodyHtml = true,
                   subject = $"Canje de Premio - Ruta Digital"
               },
               data: data);
        }

        return Ok(result);
    }
}
