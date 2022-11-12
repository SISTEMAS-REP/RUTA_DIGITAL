namespace Prod.RutaDigital.Entidades;

public class PremioResponse : Premio
{
    public string? nivel_madurez { get; set; }
    public string? tipo_canje { get; set; }    
    public byte[]? numArray { get; set; }
    
    public string? etiqueta { get; set; }
    public string? foto_tipo { get; set; }
    public byte[]? fotoTipoArray { get; set; }
}
