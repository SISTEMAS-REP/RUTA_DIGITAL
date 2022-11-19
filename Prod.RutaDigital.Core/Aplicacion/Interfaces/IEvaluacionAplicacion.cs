using Release.Helper;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Aplicacion.Interfaces;

public interface IEvaluacionAplicacion
{
    Task<StatusResponse<IEnumerable<EvaluacionResponse>>>
        ListarEvaluacion(EvaluacionRequest request);

    Task<StatusResponse<int>>
        InsertarEvaluacion(EvaluacionRequest request);

    Task<StatusResponse<int>>
        ActualizarEvaluacion(EvaluacionRequest request);
}
