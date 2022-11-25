namespace Prod.RutaDigital.Entidades;

public class ModuloResponse : Modulo
{
    public IEnumerable<PreguntaResponse>? preguntas { get; set; }

    public IEnumerable<NivelMadurezResponse>? niveles { get; set; }

    public IEnumerable<CapacitacionResultadoResponse>? capacitaciones { get; set; }
}
