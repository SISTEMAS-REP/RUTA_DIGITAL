using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;
        public EventoAplicacion(IEventoUnitOfWork eventoUnitOfWork, IConfiguration configuration)
        {
            this._uow = eventoUnitOfWork;
            this._configuration = configuration;
        }
        public async Task<StatusResponse<List<EventoResponse>>> ListarEventos(EventoRequest request)
        {
            string connectionString = this._configuration.GetSection("fileServer").Value;
            var resultado = new StatusResponse<List<EventoResponse>>();
            try
            {
                var data = await _uow
                    .ListarEventos(request);

                foreach (EventoResponse x in data)
                {
                    var imagenPath = Path.Combine(connectionString, x.foto!);
                    x.numArray = File.ReadAllBytes(imagenPath);
                }

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
