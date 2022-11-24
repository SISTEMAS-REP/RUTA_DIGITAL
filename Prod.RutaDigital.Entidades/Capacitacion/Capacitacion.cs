namespace Prod.RutaDigital.Entidades;

public class Capacitacion
{
    public int id_capacitacion { get; set; }
    public int id_capacitacion_resultado { get; set; }
    public DateTime? fecha_inicio { get; set; }
    public DateTime? fecha_fin { get; set; }
    public bool test_aprobado { get; set; }
}
