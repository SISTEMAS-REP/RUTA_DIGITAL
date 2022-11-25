namespace Prod.RutaDigital.Entidades;

public class TestAvanceRequest
{
    public int id_capacitacion_resultado { get; set; }
    public IEnumerable<CapacitacionDetRequest>? respuestas { get; set; }
}
