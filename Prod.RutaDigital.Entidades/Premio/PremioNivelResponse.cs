using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod.RutaDigital.Entidades
{
    public class PremioNivelResponse
    {
        public string? codigo { get; set; }
        public string? nombre { get; set; }
        public string? descripcion { get; set; }
        public decimal? valor_min { get; set; }
        public decimal? valor_max { get; set; }
    }
}
