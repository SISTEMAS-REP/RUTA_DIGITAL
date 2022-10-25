
using Prod.RutaDigital.Entidades;
using Release.Helper;

namespace Prod.RutaDigital.Core.Aplicacion.Interfaces
{
    public interface IBannerAplicacion
    {
        Task<StatusResponse<List<BannerResponse>>> ListarBannerPrincipal();
        Task<StatusResponse<List<BannerResponse>>> ListarBannerPiePagina();
    }
}
