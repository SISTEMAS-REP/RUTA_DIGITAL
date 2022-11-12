using Release.Helper;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Aplicacion;

public class EventoAplicacion : IEventoAplicacion
{
    private readonly IUnitOfWork _uow;

    public EventoAplicacion(IUnitOfWork uow)
    {
        _uow = uow;
    }
    public async Task<StatusResponse<IEnumerable<EventoResponse>>> 
        ListarEventos(EventoRequest request)
    {
        var resultado = new StatusResponse<IEnumerable<EventoResponse>>();
        try
        {
            var data = await _uow
                .ListarEventos(request);

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
