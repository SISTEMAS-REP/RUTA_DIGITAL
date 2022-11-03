using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod.RutaDigital.Entidades
{
    public class BannerResponse
    {
        public string? foto { get; set; }
        public string? titulo { get; set; }
        public string? nombre_empresa { get; set; }
        public string? tipo_empresa { get; set; }
        public string? url_web { get; set; }
        public string? accion { get; set; }
        public string? logo { get; set; }
        public string? descripcion { get; set; }
        public byte[]? numArray { get; set; }
    }
}
