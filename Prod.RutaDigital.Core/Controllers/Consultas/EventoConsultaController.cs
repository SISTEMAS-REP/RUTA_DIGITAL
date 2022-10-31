using Microsoft.AspNetCore.Mvc;
using Prod.RutaDigital.Core.Aplicacion;
using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Entidades;
using Release.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod.RutaDigital.Core.Controllers.Consultas
{
    [ApiController]
    [Route("[controller]")]
    public class EventoConsultaController : ControllerBase
    {
        private readonly IEventoAplicacion _eventoAplicacion;
        public EventoConsultaController(IEventoAplicacion eventoAplicacion)
        {
            _eventoAplicacion = eventoAplicacion;
        }

        [HttpGet]
        [Route("ListarEventos")]
        public async Task<StatusResponse<List<EventoResponse>>> ListarEventos(EventoRequest request)
        {
            return await _eventoAplicacion
                .ListarEventos(request);
        }
    }
}
