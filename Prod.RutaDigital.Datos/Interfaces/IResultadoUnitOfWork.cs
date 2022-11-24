using Release.Helper.Data.ICore;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Datos.Interfaces;

public partial interface IUnitOfWork : IBaseUnitOfWork
{
    Task<IEnumerable<ResultadoResponse>>
        ListarResultados(ResultadoRequest request);

    Task<int>
        InsertarResultado(ResultadoRequest request);
}