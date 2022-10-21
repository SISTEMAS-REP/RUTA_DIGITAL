using Prod.RutaDigital.Datos.Comun;
using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;
using Release.Helper.Data.Core;

namespace Prod.RutaDigital.Datos;

public class WeatherForecastUnitOfWork : UnitOfWork, IWeatherForecastUnitOfWork
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public WeatherForecastUnitOfWork(IDbContext context) 
        : base(context)
    {

    }

    public async Task<IEnumerable<WeatherForecastResponse>> 
        Listar(WeatherForecastRequest request)
    {
        var result = Enumerable
            .Range(1, 5)
            .Select(index => new WeatherForecastResponse
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            });

        return await Task.FromResult(result);
    }
}
