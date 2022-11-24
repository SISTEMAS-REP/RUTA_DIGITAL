using Release.Helper;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Aplicacion;

public class RecursoDetAplicacion : IRecursoDetAplicacion
{
    private readonly IUnitOfWork _uow;

    public RecursoDetAplicacion(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<StatusResponse<IEnumerable<RecursoDetResponse>>>
        ListarRecursoDetalles(RecursoDetRequest request)
    {
        var resultado = new StatusResponse<IEnumerable<RecursoDetResponse>>();
        try
        {
            var data = await _uow
                .ListarRecursoDetalles(request);

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
