using Release.Helper;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Aplicacion;

public class CapacitacionResultadoAplicacion : ICapacitacionResultadoAplicacion
{
    private readonly IUnitOfWork _uow;

    public CapacitacionResultadoAplicacion(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<StatusResponse<IEnumerable<CapacitacionResultadoResponse>>>
        ListarCapacitacionesResultado(CapacitacionResultadoRequest request)
    {
        var resultado = new StatusResponse<IEnumerable<CapacitacionResultadoResponse>>();
        try
        {
            var data = await _uow
                .ListarCapacitacionesResultado(request);

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

    public async Task<StatusResponse<int>>
        InsertarCapacitacionResultado(CapacitacionResultadoRequest request)
    {
        var resultado = new StatusResponse<int>();
        try
        {
            var data = await _uow
                .InsertarCapacitacionResultado(request);

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

    public async Task<StatusResponse<int>>
        ActualizarCapacitacionResultado(CapacitacionResultadoRequest request)
    {
        var resultado = new StatusResponse<int>();
        try
        {
            var data = await _uow
                .ActualizarCapacitacionResultado(request);

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
