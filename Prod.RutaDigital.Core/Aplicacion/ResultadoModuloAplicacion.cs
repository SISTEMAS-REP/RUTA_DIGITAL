using Release.Helper;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Aplicacion;

public class ResultadoModuloAplicacion : IResultadoModuloAplicacion
{
    private readonly IUnitOfWork _uow;

    public ResultadoModuloAplicacion(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<StatusResponse<IEnumerable<ResultadoModuloResponse>>>
        ListarResultadoModulos(ResultadoModuloRequest request)
    {
        var resultado = new StatusResponse<IEnumerable<ResultadoModuloResponse>>();
        try
        {
            var data = await _uow
                .ListarResultadoModulos(request);

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

    public async Task<StatusResponse<IEnumerable<ResultadoModuloResponse>>>
     ListarResultadoModulosHistorico(ResultadoModuloRequest request)
    {
        var resultado = new StatusResponse<IEnumerable<ResultadoModuloResponse>>();
        try
        {
            var data = await _uow
                .ListarResultadoModulosHistorico(request);

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
        InsertarResultadoModulo(ResultadoModuloRequest request)
    {
        var resultado = new StatusResponse<int>();
        try
        {
            var data = await _uow
                .InsertarResultadoModulo(request);

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
