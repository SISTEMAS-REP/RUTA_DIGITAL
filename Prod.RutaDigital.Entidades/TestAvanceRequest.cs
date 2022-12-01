namespace Prod.RutaDigital.Entidades;

public class TestAvanceRequest
{
    public int id_capacitacion_resultado { get; set; }
    public int id_modulo { get; set; }
    public IEnumerable<CapacitacionDetRequest>? respuestas { get; set; }
}
