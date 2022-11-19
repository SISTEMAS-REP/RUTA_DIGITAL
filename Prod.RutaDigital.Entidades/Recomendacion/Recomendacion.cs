namespace Prod.RutaDigital.Entidades;

public class Recomendacion : Auditoria
{
    public int id_recomendacion { get; set; }
    public int id_modulo { get; set; }
    public int id_nivel_madurez { get; set; }
    public int orden { get; set; }
    public string? codigo { get; set; }
    public string? descripcion { get; set; }
    public int puntos_produce { get; set; }
    public string? imagen { get; set; }
}
