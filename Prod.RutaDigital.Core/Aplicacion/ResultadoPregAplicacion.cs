using Release.Helper;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Aplicacion;

public class ResultadoPregAplicacion : IResultadoPregAplicacion
{
    private readonly IUnitOfWork _uow;

    public ResultadoPregAplicacion(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<StatusResponse<int>>
        InsertarResultadoPreg(ResultadoPregRequest request)
    {
        var resultado = new StatusResponse<int>();
        try
        {
            var data = await _uow
                .InsertarResultadoPreg(request);

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
