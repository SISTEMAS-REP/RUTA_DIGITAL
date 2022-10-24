using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;
using Release.Helper;

namespace Prod.RutaDigital.Core.Aplicacion.Procesos;

public class PokemonProceso : AccionGenerica<PokemonRequest>
{
    private IPokemonUnitOfWork _uow;

    public PokemonProceso(IPokemonUnitOfWork uow)
    {
        _uow = uow;
    }

    protected override StatusResponse 
        Registrar(PokemonRequest request)
    {
        var sr = new StatusResponse { Data = 0 };

        return sr;
    }
}
