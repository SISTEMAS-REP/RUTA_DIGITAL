namespace Prod.RutaDigital.Entidades;

public class CapacitacionResultado : Auditoria
{
    public int id_capacitacion_resultado { get; set; }
    public int id_resultado { get; set; }
    public int id_recomendacion { get; set; }
    public DateTime? fecha_inicio { get; set; }
    public DateTime? fecha_fin { get; set; }
    public decimal progreso { get; set; }
    public bool concluido { get; set; }
    public int calificacion { get; set; }
}
