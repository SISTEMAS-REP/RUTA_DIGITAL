using Prod.RutaDigital.Entidades;
using Release.Helper;

namespace Prod.RutaDigital.Core.Aplicacion.Interfaces
{
    public interface IEventoAplicacion
    {
        Task<StatusResponse<List<EventoResponse>>> ListarEventos(EventoRequest request);
    }
}
