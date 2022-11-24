namespace Prod.RutaDigital.Entidades;

public class Pregunta
{
    public int id_pregunta { get; set; }
    public int id_modulo { get; set; }
    public int id_tipo_test { get; set; }
    public int id_recomendacion { get; set; }
    public int id_tipo_respuesta { get; set; }
    public int orden { get; set; }
    public string? codigo { get; set; }
    public string? descripcion { get; set; }
}
