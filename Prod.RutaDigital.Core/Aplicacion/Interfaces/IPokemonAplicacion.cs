using Prod.RutaDigital.Entidades;
using Release.Helper;

namespace Prod.RutaDigital.Core.Aplicacion.Interfaces;

public interface IPokemonAplicacion
{
    Task<StatusResponse<List<PokemonResponse>>>
        Listar(PokemonRequest request);
}