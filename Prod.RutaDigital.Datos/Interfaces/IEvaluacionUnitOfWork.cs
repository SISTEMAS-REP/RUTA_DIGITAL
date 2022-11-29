using Release.Helper.Data.ICore;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Datos.Interfaces;

public partial interface IUnitOfWork : IBaseUnitOfWork
{
    Task<IEnumerable<EvaluacionResponse>>
        ListarEvaluacion(EvaluacionRequest request);

    Task<int>
        InsertarEvaluacion(EvaluacionRequest request);

    Task<int>
        ActualizarEvaluacion(EvaluacionRequest request);
    Task<IEnumerable<EvaluacionResponse>> ListarEvaluacionHistorico(EvaluacionRequest request);
}