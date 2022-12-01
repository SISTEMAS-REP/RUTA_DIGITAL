namespace Prod.RutaDigital.Entidades;

public class ResultadoAvanceResponse
{
    public ResultadoResponse Resultado { get; set; }
    public IEnumerable<AvanceModuloResponse> AvanceModulos { get; set; }
    public IEnumerable<NivelMadurezResponse> NivelesMadurez { get; set; }
}
