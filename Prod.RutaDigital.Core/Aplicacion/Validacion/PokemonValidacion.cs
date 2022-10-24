using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;
using Release.Helper;

namespace Prod.RutaDigital.Core.Aplicacion.Validacion;

public class PokemonValidacion : ValidacionGenerica
{
    private IPokemonUnitOfWork _uow;

    public PokemonValidacion(IPokemonUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<List<string>> 
        Validar(PokemonRequest request)
    {
        /*if (string.IsNullOrWhiteSpace(request.))
        {
            Msg.Add("Es un valor requerido");
        }*/

        return await Task.FromResult(Msg);
    }
}
