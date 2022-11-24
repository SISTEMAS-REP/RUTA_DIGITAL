namespace Prod.RutaDigital.Entidades;

public class CapacitacionDet
{
    public int id_capacitacion_det { get; set; }
    public int id_capacitacion { get; set; }
    public int id_pregunta { get; set; }
    public int id_alternativa { get; set; }
    public bool respuesta { get; set; }
}
