namespace Prod.RutaDigital.Entidades;

public class AvanceModuloResponse : AvanceModulo
{
    public string orden_modulo { get; set; }
    public string nombre_modulo { get; set; }
    
    public string nombre_nivel_madurez { get; set; }

    public int rank_desc { get; set; }
    public int resultado { get; set; }
}
