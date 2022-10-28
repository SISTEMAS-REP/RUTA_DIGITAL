﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prod.RutaDigital.Presentacion.Configuracion.Proxys;

namespace Prod.RutaDigital.Presentacion.Angular.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly EventoConsultaProxy _eventoConsultaProxy;
        public EventoController(EventoConsultaProxy eventoConsultaProxy)
        {
            _eventoConsultaProxy = eventoConsultaProxy;
        }
        [AllowAnonymous]
        [HttpGet("ListarEventos")]
        public async Task<IActionResult> ListarEventos()
        {
            var results = await _eventoConsultaProxy.ListarEventos();
            return Ok(results);
        }
    }
}
