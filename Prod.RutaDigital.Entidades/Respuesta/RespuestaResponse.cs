namespace Prod.RutaDigital.Entidades;

public class RespuestaResponse : Respuesta
{
    public int orden_modulo { get; set; }
    public string? nombre_modulo { get; set; }
    public string? descripcion_modulo { get; set; }
    public string? imagen_modulo { get; set; }
    
    public int orden_pregunta { get; set; }
    public string? descripcion_pregunta { get; set; }

    public int orden_alternativa { get; set; }
    public string? descripcion_alternativa { get; set; }
}
