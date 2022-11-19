namespace Prod.RutaDigital.Entidades;

public class Alternativa
{
    public int id_alternativa { get; set; }
    public int id_pregunta { get; set; }
    public int orden { get; set; }
    public string? codigo { get; set; }
    public string? descripcion { get; set; }
    public decimal peso { get; set; }
}
