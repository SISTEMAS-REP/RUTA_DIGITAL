using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod.RutaDigital.Entidades
{
    public class PerfilAvanceEstadisticaResponse
    {
        public int puntos_canjeados { get; set; }
        public int puntos_obtenidos { get; set; }
        public int puntos_disponibles {get; set; }
        public int premios_canjeados { get; set; }
        public DateTime? fecha_inicio_capacitacion { get; set; }

    }
}
