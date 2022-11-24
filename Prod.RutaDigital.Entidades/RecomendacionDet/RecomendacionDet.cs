namespace Prod.RutaDigital.Entidades;

public class RecomendacionDet
{
    public int id_recomendacion_det { get; set; }
    public int id_recomendacion { get; set; }
    public string? pregunta { get; set; }
    public string? respuesta { get; set; }
    public string? icono { get; set; }
}
