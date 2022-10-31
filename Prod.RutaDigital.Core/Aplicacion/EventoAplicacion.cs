using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;
using Release.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod.RutaDigital.Core.Aplicacion
{
    public class EventoAplicacion : IEventoAplicacion
    {
        private readonly IEventoUnitOfWork _uow;
        public EventoAplicacion(IEventoUnitOfWork eventoUnitOfWork)
        {
            this._uow = eventoUnitOfWork;
        }
        public async Task<StatusResponse<List<EventoResponse>>> ListarEventos(EventoRequest request)
        {
            var resultado = new StatusResponse<List<EventoResponse>>();
            try
            {
                var data = await _uow
                    .ListarEventos(request);
                resultado.Success = true;
                resultado.Data = data.ToList();
            }
            catch (Exception ex)
            {
                resultado.Success = true;
                resultado.Messages = new()
            {
                ex.Message
            };
            }

            return resultado;
        }
    }
}
