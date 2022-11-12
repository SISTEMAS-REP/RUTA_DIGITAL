namespace Prod.RutaDigital.Entidades;

public class EventoResponse : Evento
{
    public string? modalidad { get; set; }
    public string? plataforma { get; set; }
    public byte[]? numArray { get; set; }
}
