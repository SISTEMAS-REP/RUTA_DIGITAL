using Prod.RutaDigital.Datos.Comun;
using Prod.RutaDigital.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod.RutaDigital.Datos.Interfaces;
public interface IBannerUnitOfWork : IUnitOfWork
{
    Task<IEnumerable<BannerResponse>> ListarBannerPrincipal();
    Task<IEnumerable<BannerResponse>> ListarBannerPiePagina();
}
