namespace Prod.RutaDigital.Entidades;

public class Recurso
{
    public int id_recurso { get; set; }
    public int id_recomendacion { get; set; }
    public string? codigo { get; set; }
    public string? descripcion { get; set; }
    public string? icono { get; set; }
    public string? enlace_ruta { get; set; }
    public string? red_social { get; set; }
    public string? hashtag { get; set; }
}
