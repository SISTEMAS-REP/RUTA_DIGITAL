namespace Prod.RutaDigital.Entidades
{
    public class EventoResponse
    {
        public int id_evento { get; set; }
        public int id_tipo_modalidad { get; set; }
        public string? foto { get; set; }
        public string? nombre { get; set; }
        public string? descripcion_corta { get; set; }
        public string? descripcion { get; set; }
        public string? lugar { get; set; }
        public string? direccion { get; set; }
        public string? url_evento { get; set; }
        public DateTime? fecha_evento { get; set; }
        public string? modalidad { get; set; }
        public double latitud { get; set; }
        public double longitud { get; set; }
        public string? plataforma { get; set; }
        public byte[]? numArray { get; set; }
    }
}
