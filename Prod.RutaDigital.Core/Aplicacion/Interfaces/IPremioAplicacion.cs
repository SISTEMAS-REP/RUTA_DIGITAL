using Prod.RutaDigital.Entidades;
using Release.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod.RutaDigital.Core.Aplicacion.Interfaces
{
    public interface IPremioAplicacion
    {
        Task<StatusResponse<List<PremioPublicidadResponse>>> ListarPublicidadPremio();
        Task<StatusResponse<List<PremioTipoResponse>>> ListarTipoPremio();
        Task<StatusResponse<List<PremioResponse>>> ListarPremio();
    }
}
