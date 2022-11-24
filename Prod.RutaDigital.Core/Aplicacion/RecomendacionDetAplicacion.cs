using Release.Helper;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Aplicacion;

public class RecomendacionDetAplicacion : IRecomendacionDetAplicacion
{
    private readonly IUnitOfWork _uow;

    public RecomendacionDetAplicacion(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<StatusResponse<IEnumerable<RecomendacionDetResponse>>>
        ListarRecomendacionDetalles(RecomendacionDetRequest request)
    {
        var resultado = new StatusResponse<IEnumerable<RecomendacionDetResponse>>();
        try
        {
            var data = await _uow
                .ListarRecomendacionDetalles(request);

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
