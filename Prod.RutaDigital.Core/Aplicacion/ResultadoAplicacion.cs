using Release.Helper;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Aplicacion;

public class ResultadoAplicacion : IResultadoAplicacion
{
    private readonly IUnitOfWork _uow;

    public ResultadoAplicacion(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<StatusResponse<IEnumerable<ResultadoResponse>>>
        ListarResultados(ResultadoRequest request)
    {
        var resultado = new StatusResponse<IEnumerable<ResultadoResponse>>();

        try
        {
            var data = await _uow
                .ListarResultados(request);

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

    public async Task<StatusResponse<IEnumerable<ResultadoResponse>>>
       ListarResultadosHistorico(ResultadoRequest request)
    {
        var resultado = new StatusResponse<IEnumerable<ResultadoResponse>>();

        try
        {
            var data = await _uow
                .ListarResultadosHistorico(request);

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
        InsertarResultado(ResultadoRequest request)
    {
        var resultado = new StatusResponse<int>();
        try
        {
            var data = await _uow
                .InsertarResultado(request);

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
