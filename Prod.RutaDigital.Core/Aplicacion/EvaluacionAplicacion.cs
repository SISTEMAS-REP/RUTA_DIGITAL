using Release.Helper;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Aplicacion;

public class EvaluacionAplicacion : IEvaluacionAplicacion
{
    private readonly IUnitOfWork _uow;

    public EvaluacionAplicacion(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<StatusResponse<IEnumerable<EvaluacionResponse>>>
        ListarEvaluacion(EvaluacionRequest request)
    {
        var resultado = new StatusResponse<IEnumerable<EvaluacionResponse>>();
        try
        {
            var data = await _uow
                .ListarEvaluacion(request);

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
        InsertarEvaluacion(EvaluacionRequest request)
    {
        var resultado = new StatusResponse<int>();
        try
        {
            var data = await _uow
                .InsertarEvaluacion(request);

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
        ActualizarEvaluacion(EvaluacionRequest request)
    {
        var resultado = new StatusResponse<int>();
        try
        {
            var data = await _uow
                .ActualizarEvaluacion(request);

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

    public async Task<StatusResponse<IEnumerable<EvaluacionResponse>>>ListarEvaluacionHistorico(EvaluacionRequest request)
    {
        var resultado = new StatusResponse<IEnumerable<EvaluacionResponse>>();
        try
        {
            var data = await _uow
                .ListarEvaluacionHistorico(request);

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
