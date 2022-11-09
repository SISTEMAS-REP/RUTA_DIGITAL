using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod.RutaDigital.Entidades
{
    public class PremioRequest
    {
        public int? CantReg { get; set; }
        public int? IdListCatalogo { get; set; }
        public int? id_premio { get; set; }
        public string? IdTipo { get; set; }
        public string? IdNivel { get; set; }
        public int? PuntosDesde { get; set; }
        public int? PuntosHasta { get; set; }
    }
}
