using Prod.RutaDigital.Datos.Comun;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Datos.Interfaces;

public interface IPokemonUnitOfWork : IUnitOfWork
{
    Task<IEnumerable<PokemonResponse>>
        Listar(PokemonRequest request);
}
