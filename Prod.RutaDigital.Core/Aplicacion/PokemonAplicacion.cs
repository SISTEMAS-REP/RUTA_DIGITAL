using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;
using Release.Helper;

namespace Prod.RutaDigital.Core.Aplicacion;

public class PokemonAplicacion : IPokemonAplicacion
{
	private IPokemonUnitOfWork _uow;

	public PokemonAplicacion(IPokemonUnitOfWork uow)
	{
		_uow = uow;
	}

	public async Task<StatusResponse<List<PokemonResponse>>> 
        Listar(PokemonRequest request)
    {
        var resultado = new StatusResponse<List<PokemonResponse>>();

        try
		{
            var data = await _uow
                .Listar(request);

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