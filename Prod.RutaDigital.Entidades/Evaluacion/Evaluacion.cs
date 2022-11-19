namespace Prod.RutaDigital.Entidades;

public class Evaluacion : Auditoria
{
    public int id_evaluacion { get; set; }
    public int id_usuario_extranet { get; set; }
    public DateTime fecha_inicio { get; set; }
    public DateTime? fecha_fin { get; set; }
    public int modulo_activo { get; set; }
    public int pregunta_activa { get; set; }
    public bool concluido { get; set; }
}
