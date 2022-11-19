namespace Prod.RutaDigital.Entidades;

public class PreguntaResponse : Pregunta
{
    public IEnumerable<RespuestaResponse> respuestas { get; set; }
}