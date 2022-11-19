using Release.Helper;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Aplicacion;

public class RecomendacionAplicacion : IRecomendacionAplicacion
{
    private readonly IUnitOfWork _uow;

    public RecomendacionAplicacion(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<StatusResponse<IEnumerable<RecomendacionResponse>>>
        ListarRecomendaciones(RecomendacionRequest request)
    {
        var resultado = new StatusResponse<IEnumerable<RecomendacionResponse>>();
        try
        {
            var data = await _uow
                .ListarRecomendaciones(request);

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
