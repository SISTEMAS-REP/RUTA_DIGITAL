using Release.Helper;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Aplicacion;

public class RecursoAplicacion : IRecursoAplicacion
{
    private readonly IUnitOfWork _uow;

    public RecursoAplicacion(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<StatusResponse<IEnumerable<RecursoResponse>>>
        ListarRecursos(RecursoRequest request)
    {
        var resultado = new StatusResponse<IEnumerable<RecursoResponse>>();
        try
        {
            var data = await _uow
                .ListarRecursos(request);

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
