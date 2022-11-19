namespace Prod.RutaDigital.Entidades;

public class Resultado : Auditoria
{
    public int id_resultado { get; set; }
    public int id_evaluacion { get; set; }
    public int id_tipo_test { get; set; }
    public int id_usuario_extranet { get; set; }
    public decimal resultado { get; set; }
}
