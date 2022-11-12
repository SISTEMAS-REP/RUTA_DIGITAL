namespace Prod.RutaDigital.Entidades;

public class PremioRequest : Premio
{
    public int? CantReg { get; set; }
    public int? IdListCatalogo { get; set; }
    public string? IdTipo { get; set; }
    public string? IdNivel { get; set; }
    public int? PuntosDesde { get; set; }
    public int? PuntosHasta { get; set; }
}
