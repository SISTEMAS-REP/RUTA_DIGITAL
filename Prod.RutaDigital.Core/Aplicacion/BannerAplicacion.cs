using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;
using Release.Helper;

namespace Prod.RutaDigital.Core.Aplicacion;

public class BannerAplicacion : IBannerAplicacion
{
    private readonly IBannerUnitOfWork _uow;
    public BannerAplicacion(
        IBannerUnitOfWork bannerUnitOfWork
        )
    {
        this._uow = bannerUnitOfWork;
    }
    public async Task<StatusResponse<List<BannerResponse>>> ListarBannerPrincipal()
    {
        var resultado = new StatusResponse<List<BannerResponse>>();

        try
        {
            var data = await _uow
                .ListarBannerPrincipal();

            resultado.Success = true;
            resultado.Data = data.ToList();
        }
        catch (Exception ex)
        {
            resultado.Success = true;
            resultado.Messages = new()
            {
                ex.Message
            };
        }

        return resultado;
    }

    public async Task<StatusResponse<List<BannerResponse>>> ListarBannerPiePagina()
    {
        var resultado = new StatusResponse<List<BannerResponse>>();

        try
        {
            var data = await _uow
                .ListarBannerPiePagina();

            resultado.Success = true;
            resultado.Data = data.ToList();
        }
        catch (Exception ex)
        {
            resultado.Success = true;
            resultado.Messages = new()
            {
                ex.Message
            };
        }

        return resultado;
    }
}
