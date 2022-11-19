namespace Prod.RutaDigital.Entidades;

public class ResultadoModulo : Auditoria
{
    public int id_resultado_modulo { get; set; }
    public int id_resultado { get; set; }
    public int id_modulo { get; set; }
    public decimal peso_modulo { get; set; }
    public int cant_preg { get; set; }
    public decimal resultado_modulo { get; set; }
    public decimal prom_result_modulo { get; set; }
}
