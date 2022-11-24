namespace Prod.RutaDigital.Entidades;

public class ResultadoAutodiagnosticoResponse
{
    public ResultadoResponse Resultado { get; set; }
    public IEnumerable<ResultadoModuloResponse> ResultadoModulos { get; set; }
    public IEnumerable<NivelMadurezResponse> NivelesMadurez { get; set; }
}