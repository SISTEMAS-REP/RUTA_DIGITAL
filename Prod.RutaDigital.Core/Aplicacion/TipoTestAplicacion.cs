using Release.Helper;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Aplicacion;

public class TipoTestAplicacion : ITipoTestAplicacion
{
    private readonly IUnitOfWork _uow;

    public TipoTestAplicacion(IUnitOfWork uow)
    {
        _uow = uow;
    }
    public async Task<StatusResponse<IEnumerable<TipoTestResponse>>>
        ListarTiposTest(TipoTestRequest request)
    {
        var resultado = new StatusResponse<IEnumerable<TipoTestResponse>>();
        try
        {
            var data = await _uow
                .ListarTiposTest(request);

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
