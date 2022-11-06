using Prod.RutaDigital.Datos.Comun;
using Prod.RutaDigital.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod.RutaDigital.Datos.Interfaces
{
    public interface IPremioUnitOfWork : IUnitOfWork
    {
        Task<IEnumerable<PremioPublicidadResponse>> ListarPublicidadPremio();
        Task<IEnumerable<PremioTipoResponse>> ListarTipoPremio();
        Task<IEnumerable<PremioResponse>> ListarPremio();
    }
}
