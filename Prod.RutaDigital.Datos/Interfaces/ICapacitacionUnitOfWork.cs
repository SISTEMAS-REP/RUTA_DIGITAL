using Release.Helper.Data.ICore;

using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Datos.Interfaces;

public partial interface IUnitOfWork : IBaseUnitOfWork
{
    Task<IEnumerable<CapacitacionResponse>>
        ListarCapacitaciones(CapacitacionRequest request);

    Task<int>
        InsertarCapacitacion(CapacitacionRequest request);
}