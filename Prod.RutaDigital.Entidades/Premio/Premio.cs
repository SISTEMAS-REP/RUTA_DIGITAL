﻿namespace Prod.RutaDigital.Entidades;

public class Premio
{
    public int id_premio { get; set; }
    public int id_tipo_premio { get; set; }
    public string? tipo_premio { get; set; }
    public int id_nivel_madurez { get; set; }
    public int id_tipo_canje { get; set; }
    public string? foto { get; set; }
    public string? nombre { get; set; }
    public string? descripcion_corta { get; set; }
    public string? detalle_premio { get; set; }
    public int puntos_produce { get; set; }
    public string? correo { get; set; }
}