using Release.Helper.Data.ICore;

namespace Prod.RutaDigital.Datos.Interfaces;

public partial interface IUnitOfWork : IBaseUnitOfWork
{
    void ExecDispose();
}