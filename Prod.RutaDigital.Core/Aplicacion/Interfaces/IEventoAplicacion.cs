using Release.Helper;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Aplicacion.Interfaces;

public interface IEventoAplicacion
{
    Task<StatusResponse<IEnumerable<EventoResponse>>>
        ListarEventos(EventoRequest request);
}
