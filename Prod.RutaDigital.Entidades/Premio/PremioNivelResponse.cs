using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod.RutaDigital.Entidades
{
    public class PremioNivelResponse
    {
        public int? codigo { get; set; }
        public string? nombre { get; set; }
        public string? descripcion { get; set; }
        public int? valor_min { get; set; }
        public int? valor_max { get; set; }
    }
}
