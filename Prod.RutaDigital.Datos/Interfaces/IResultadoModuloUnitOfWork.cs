using Release.Helper.Data.ICore;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Datos.Interfaces;

public partial interface IUnitOfWork : IBaseUnitOfWork
{
    Task<IEnumerable<ResultadoModuloResponse>>
        ListarResultadoModulos(ResultadoModuloRequest request);
    Task<IEnumerable<ResultadoModuloResponse>>
       ListarResultadoModulosHistorico(ResultadoModuloRequest request);

    Task<int>
        InsertarResultadoModulo(ResultadoModuloRequest request);
}