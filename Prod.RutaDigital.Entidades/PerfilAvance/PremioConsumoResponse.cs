using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod.RutaDigital.Entidades
{
    public class PremioConsumoResponse
    {
        public int? id_premio { get; set; }
        public string? nombre_premio { get; set; }
        public string? descripcion { get; set; }
        public string? foto { get; set; }
        public Int16? puntos_consumo { get; set; }
        public DateTime? fecha_consumo { get; set; }
    }
}
