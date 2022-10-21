using Microsoft.AspNetCore.Mvc;
using Prod.RutaDigital.Entidades;
using Prod.RutaDigital.Presentacion.Configuracion.Proxys;

namespace Prod.RutaDigital.Presentacion.Angular.Controllers;

[ApiController]
[Route("[controller]")]
public class PokemonController : Controller
{
    private readonly PokemonConsultaProxy _pokemonConsulta;

    public PokemonController(PokemonConsultaProxy pokemonConsulta)
    {
        _pokemonConsulta = pokemonConsulta;
    }

    [HttpGet]
    public async Task<IActionResult>
        GetPokemons([FromQuery] PokemonRequest request)
    {
        var results = await _pokemonConsulta
            .Listar(request);
        return Ok(new JsonResult(results));
    }
}
