namespace Prod.RutaDigital.Entidades;

public class RecursoResponse : Recurso
{
    public IEnumerable<RecursoDet> detalle { get; set; }
}
