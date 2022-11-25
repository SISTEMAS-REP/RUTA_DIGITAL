namespace Prod.RutaDigital.Entidades;

public class Capacitacion : Auditoria
{
    public int id_capacitacion { get; set; }
    public int id_capacitacion_resultado { get; set; }
    public DateTime? fecha { get; set; }
    public bool test_aprobado { get; set; }
}
