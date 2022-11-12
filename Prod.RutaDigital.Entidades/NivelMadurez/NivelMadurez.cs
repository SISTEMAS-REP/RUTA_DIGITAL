namespace Prod.RutaDigital.Entidades;

public class NivelMadurez
{
    public int id_nivel_madurez { get; set; }
    public string? codigo { get; set; }
    public string? nombre { get; set; }
    public string? descripcion { get; set; }
    public decimal valor_min { get; set; }
    public decimal valor_max { get; set; }
}
