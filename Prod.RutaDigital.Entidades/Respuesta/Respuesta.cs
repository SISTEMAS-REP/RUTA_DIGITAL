namespace Prod.RutaDigital.Entidades;

public class Respuesta : Auditoria
{
    public int id_respuesta { get; set; }
    public int id_evaluacion { get; set; }
    public int id_modulo { get; set; }
    public decimal peso_modulo { get; set; }
    public int id_pregunta { get; set; }
    public int id_alternativa { get; set; }
    public decimal peso_alt { get; set; }
    public bool respuesta { get; set; }
}
