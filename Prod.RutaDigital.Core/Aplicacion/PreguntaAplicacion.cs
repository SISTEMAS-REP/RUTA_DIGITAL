using Release.Helper;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Aplicacion;

public class PreguntaAplicacion : IPreguntaAplicacion
{
    private readonly IUnitOfWork _uow;

    public PreguntaAplicacion(IUnitOfWork uow)
    {
        _uow = uow;
    }
    public async Task<StatusResponse<IEnumerable<PreguntaResponse>>>
        ListarPreguntas(PreguntaRequest request)
    {
        var resultado = new StatusResponse<IEnumerable<PreguntaResponse>>();
        try
        {
            var data = await _uow
                .ListarPreguntas(request);

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
