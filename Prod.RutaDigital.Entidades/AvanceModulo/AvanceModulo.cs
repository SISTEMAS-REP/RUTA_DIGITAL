namespace Prod.RutaDigital.Entidades;

public class AvanceModulo : Auditoria
{
    public int id_avance_modulo { get; set; }
    public int id_resultado { get; set; }
    public int id_modulo { get; set; }
    public int id_nivel_madurez { get; set; }
}
