using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Datos.Interfaces;

namespace Prod.RutaDigital.Core.Aplicacion
{
    public class PerfilAvanceAplicacion : IPerfilAvanceAplicacion
    {
        private readonly IUnitOfWork _uow;
        public PerfilAvanceAplicacion(IUnitOfWork uow)
        {
            this._uow = uow;
        }

    }
}
