using Microsoft.AspNetCore.Mvc;
using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Entidades;
using Release.Helper;

namespace Prod.RutaDigital.Core.Controllers.Consultas;

[ApiController]
[Route("[controller]")]
public class PokemonConsultaController : ControllerBase
{
    private readonly IPokemonAplicacion _pokemonAplicacion;

	public PokemonConsultaController(IPokemonAplicacion pokemonAplicacion)
	{
		_pokemonAplicacion = pokemonAplicacion;
	}

	[HttpGet]
	[Route("Listar")]
	public async Task<StatusResponse<List<PokemonResponse>>> 
		ListarPokemons([FromQuery] PokemonRequest request)
	{
		return await _pokemonAplicacion
			.Listar(request);
	}
}
