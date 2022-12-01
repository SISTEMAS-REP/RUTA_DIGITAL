namespace Prod.RutaDigital.Entidades;

public class ResultadoModuloResponse : ResultadoModulo
{
    public string nombre_modulo { get; set; }
    public int orden_modulo { get; set; }
    public int id_nivel_madurez { get; set; }
    public string codigo_nivel_madurez { get; set; }
    public string nombre_nivel_madurez { get; set; }
    public int id_nivel_sgte { get; set; }
}
