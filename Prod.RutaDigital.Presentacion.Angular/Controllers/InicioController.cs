using Release.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Prod.RutaDigital.Entidades;
using Prod.RutaDigital.Presentacion.Configuracion;
using Prod.RutaDigital.Presentacion.Configuracion.Proxys;

namespace Prod.RutaDigital.Presentacion.Angular.Controllers;

[AllowAnonymous]
[ApiController]
[Route("[controller]")]
public class InicioController : ControllerBase
{
    private readonly PublicidadConsultaProxy _publicidadConsultaProxy;
    private readonly PublicidadPieConsultaProxy _publicidadPieConsultaProxy;
    private readonly AppVariables _appVariables;

    public InicioController(PublicidadConsultaProxy publicidadConsultaProxy,
        PublicidadPieConsultaProxy publicidadPieConsultaProxy,
        AppVariables appVariables)
    {
        _publicidadConsultaProxy = publicidadConsultaProxy;
        _publicidadPieConsultaProxy = publicidadPieConsultaProxy;
        _appVariables = appVariables;
    }

    [HttpGet("ListarBannerPrincipal")]
    public async Task<IActionResult> ListarBannerPrincipal()
    {
        var response = await _publicidadConsultaProxy
            .ListarPublicidad();

        var data = response.Data
            .Select(s =>
            {
                var imagenPath = Path.Combine(_appVariables.RutaArchivos, s.foto!);
                byte[]? numArray;

                try
                {
                    numArray = System.IO.File.ReadAllBytes(imagenPath);
                } catch
                {
                    numArray = null;
                }

                return new PublicidadResponse()
                {
                    id_publicidad = s.id_publicidad,
                    foto = s.foto,
                    titulo = s.titulo,
                    nombre_empresa = s.nombre_empresa,
                    tipo_empresa = s.tipo_empresa,
                    url_web = s.url_web,
                    accion = s.accion,
                    numArray = numArray
                };
            });

        var result = new StatusResponse<IEnumerable<PublicidadResponse>>()
        {
            Success = true,
            Data = data
        };

        return Ok(result);
    }

    [HttpGet("ListarBannerPiePagina")]
    public async Task<IActionResult> ListarBannerPiePagina()
    {
        var response = await _publicidadPieConsultaProxy
            .ListarPublicidadPie();

        var data = response.Data
            .Select(s =>
            {
                var imagenPath = Path.Combine(_appVariables.RutaArchivos, s.foto!);
                byte[]? numArray;

                try
                {
                    numArray = System.IO.File.ReadAllBytes(imagenPath);
                }
                catch
                {
                    numArray = null;
                }

                return new PublicidadPieResponse()
                {
                    id_publicidad_pie = s.id_publicidad_pie,
                    foto = s.foto,
                    logo = s.logo,
                    descripcion = s.descripcion,
                    url_web = s.url_web,
                    numArray = numArray
                };
            });

        var result = new StatusResponse<IEnumerable<PublicidadPieResponse>>()
        {
            Success = true,
            Data = data
        };

        return Ok(result);
    }
}
