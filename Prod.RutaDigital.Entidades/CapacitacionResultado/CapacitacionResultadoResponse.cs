namespace Prod.RutaDigital.Entidades;

public class CapacitacionResultadoResponse : CapacitacionResultado
{
    public int id_modulo { get; set; }
    public int orden_modulo { get; set; }
    public string? nombre_modulo { get; set; }

    public int id_nivel_madurez { get; set; }
    public string? nombre_nivel_madurez { get; set; }

    public int orden_recomendacion { get; set; }
    public string? descripcion_recomendacion { get; set; }
    public string? imagen_recomendacion { get; set; }
    public int puntos_produce { get; set; }

    public IEnumerable<ModuloResponse> modulos { get; set; }
}
