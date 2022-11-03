using Microsoft.Extensions.Configuration;
using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;
using Release.Helper;

namespace Prod.RutaDigital.Core.Aplicacion;

public class BannerAplicacion : IBannerAplicacion
{
    private readonly IBannerUnitOfWork _uow;
    private readonly IConfiguration _configuration;
    public BannerAplicacion(
        IBannerUnitOfWork bannerUnitOfWork,
        IConfiguration configuration
        )
    {
        this._uow = bannerUnitOfWork;
        this._configuration = configuration;
    }
    public async Task<StatusResponse<List<BannerResponse>>> ListarBannerPrincipal()
    {
        string connectionString = this._configuration.GetSection("fileServer").Value;
        var resultado = new StatusResponse<List<BannerResponse>>();

        try
        {
            var data = await _uow
                .ListarBannerPrincipal();

            foreach (BannerResponse x in data)
            {
                var imagenPath = Path.Combine(connectionString, x.foto!);
                x.numArray = File.ReadAllBytes(imagenPath);
            }

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
        string connectionString = this._configuration.GetSection("fileServer").Value;
        var resultado = new StatusResponse<List<BannerResponse>>();

        try
        {
            var data = await _uow
                .ListarBannerPiePagina();

            foreach (BannerResponse x in data)
            {
                var imagenPath = Path.Combine(connectionString, x.foto!);
                x.numArray = File.ReadAllBytes(imagenPath);
            }

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
