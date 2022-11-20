using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod.RutaDigital.Entidades
{
    public class PremioCanjeRequest
    {
        public int? id_premio { get; set; }
        public int? id_usuario_extranet { get; set; }
        public int? cantidad { get; set; }
        public string? usuario_registro { get; set; }
        public DateTime? fecha_registro { get; set; }
        public string? descripcion_premio { get; set; }
    }
}
