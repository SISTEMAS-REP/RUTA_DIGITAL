namespace Prod.RutaDigital.Entidades;

public class Modulo
{
    public int id_modulo { get; set; }
    public int orden { get; set; }
    public string? codigo { get; set; }
    public string? nombre { get; set; }
    public string? descripcion { get; set; }
    public decimal peso { get; set; }
    public string? imagen { get; set; }
}