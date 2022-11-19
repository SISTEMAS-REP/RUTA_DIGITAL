namespace Prod.RutaDigital.Entidades;

public class ResultadoPreg : Auditoria
{
    public int id_resultado_preg { get; set; }
    public int id_resultado_modulo { get; set; }
    public int id_pregunta { get; set; }
    public decimal peso_preg { get; set; }
    public decimal peso_alt_suma { get; set; }
    public decimal prom_result_preg { get; set; }
}
