namespace Prod.RutaDigital.Entidades;

public class NivelMadurezResponse : NivelMadurez
{
    public bool? seleccionado { get; set; }

    public IEnumerable<CapacitacionResultadoResponse>? capacitaciones { get; set; }
}
