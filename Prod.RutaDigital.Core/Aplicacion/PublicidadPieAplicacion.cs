using Release.Helper;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Aplicacion;

public class PublicidadPieAplicacion : IPublicidadPieAplicacion
{
    private readonly IUnitOfWork _uow;

    public PublicidadPieAplicacion(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<StatusResponse<IEnumerable<PublicidadPie>>>
        ListarPublicidadPie()
    {
        var resultado = new StatusResponse<IEnumerable<PublicidadPie>>();

        try
        {
            var data = await _uow
                .ListarPublicidadPie();

            resultado.Success = true;
            resultado.Data = data;
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
