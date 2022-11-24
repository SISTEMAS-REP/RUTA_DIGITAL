namespace Prod.RutaDigital.Entidades;

public class RecursoDet
{
    public int id_recurso_det { get; set; }
    public int id_recurso { get; set; }
    public string? nombre { get; set; }
    public string? descripcion { get; set; }
    public string? enlace_ruta { get; set; }
    public int id_proveedor { get; set; }
    public string? icono { get; set; }
}
