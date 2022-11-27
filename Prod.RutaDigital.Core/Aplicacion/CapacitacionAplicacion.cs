using Release.Helper;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Aplicacion;

public class CapacitacionAplicacion : ICapacitacionAplicacion
{
    private readonly IUnitOfWork _uow;

    public CapacitacionAplicacion(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<StatusResponse<IEnumerable<CapacitacionResponse>>>
        ListarCapacitaciones(CapacitacionRequest request)
    {
        var resultado = new StatusResponse<IEnumerable<CapacitacionResponse>>();
        try
        {
            var data = await _uow
                .ListarCapacitaciones(request);

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
        InsertarCapacitacion(CapacitacionRequest request)
    {
        var resultado = new StatusResponse<int>();
        try
        {
            var data = await _uow
                .InsertarCapacitacion(request);

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
