namespace Prod.RutaDigital.Entidades;

public class PreguntaResponse : Pregunta
{
    public string tipo_respuesta { get; set; }
    public IEnumerable<RespuestaResponse> respuestas { get; set; }
}