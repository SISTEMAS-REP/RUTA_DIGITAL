using Release.Helper.Data.ICore;

namespace Prod.RutaDigital.Datos.Comun;

public interface IUnitOfWork : IBaseUnitOfWork
{
    void ExecDispose();
}