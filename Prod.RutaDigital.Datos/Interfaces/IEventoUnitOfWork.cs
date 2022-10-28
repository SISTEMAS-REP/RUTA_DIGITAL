using Prod.RutaDigital.Datos.Comun;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Datos.Interfaces
{
    public interface IEventoUnitOfWork : IUnitOfWork
    {
        Task<IEnumerable<EventoResponse>> ListarEventos();
    }
}
