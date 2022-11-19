using Release.Helper;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Aplicacion;

public class RespuestaAplicacion : IRespuestaAplicacion
{
    private readonly IUnitOfWork _uow;

    public RespuestaAplicacion(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<StatusResponse<IEnumerable<RespuestaResponse>>>
        ListarRespuestas(RespuestaRequest request)
    {
        var resultado = new StatusResponse<IEnumerable<RespuestaResponse>>();
        try
        {
            var data = await _uow
                .ListarRespuestas(request);

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
        InsertarRespuesta(RespuestaRequest request)
    {
        var resultado = new StatusResponse<int>();
        try
        {
            var data = await _uow
                .InsertarRespuesta(request);

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
        ActualizarRespuesta(RespuestaRequest request)
    {
        var resultado = new StatusResponse<int>();
        try
        {
            var data = await _uow
                .ActualizarRespuesta(request);

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
