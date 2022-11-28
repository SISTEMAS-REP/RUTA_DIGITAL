using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prod.RutaDigital.Entidades;
using Prod.RutaDigital.Presentacion.Configuracion;
using Prod.RutaDigital.Presentacion.Configuracion.Proxys;
using Prod.RutaDigital.Presentacion.Configuracion.Proxys.PerfilAvance;
using Prod.ServiciosExternos.Puertos;
using Release.Helper;

namespace Prod.RutaDigital.Presentacion.Angular.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class PerfilAvanceController : ControllerBase
    {
        private readonly PerfilAvanceConsultaProxy _perfilAvanceConsultaProxy;
        private readonly AppVariables _appVariables;
        public PerfilAvanceController(PerfilAvanceConsultaProxy perfilAvanceConsultaProxy,
            AppVariables appVariables)
        {
            _perfilAvanceConsultaProxy = perfilAvanceConsultaProxy;
            _appVariables = appVariables;
        }

        [HttpGet("ListarCalculoPuntosUsuario")]
        public async Task<IActionResult> ListarCalculoPuntosUsuario([FromQuery] UsuarioExtranet request)
        {
            var result = await _perfilAvanceConsultaProxy
                .ListarCalculoPuntosUsuario(request);
            return Ok(result);
        }

        [HttpGet("ListarPremioConsumoUsuario")]
        public async Task<IActionResult> ListarPremioConsumoUsuario([FromQuery] UsuarioExtranet request)
        {
            var response = await _perfilAvanceConsultaProxy
                .ListarPremioConsumoUsuario(request);

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

                return s;
            });

            var result = new StatusResponse<IEnumerable<PremioConsumoResponse>>()
            {
                Success = true,
                Data = data
            };

            return Ok(result);
        }
    }
}

