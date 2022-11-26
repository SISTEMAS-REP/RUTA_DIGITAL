using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;
using Release.Helper;

namespace Prod.RutaDigital.Core.Aplicacion
{
    public class PerfilAvanceAplicacion : IPerfilAvanceAplicacion
    {
        private readonly IUnitOfWork _uow;
        public PerfilAvanceAplicacion(IUnitOfWork uow)
        {
            this._uow = uow;
        }

        public async Task<StatusResponse<IEnumerable<CalculoPuntosResponse>>> ListarCalculoPuntosUsuario(UsuarioExtranet request)
        {
            var resultado = new StatusResponse<IEnumerable<CalculoPuntosResponse>>();
            try
            {
                var data = await _uow
                    .ListarCalculoPuntosUsuario(request);

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

        public async Task<StatusResponse<IEnumerable<PremioConsumoResponse>>> ListarPremioConsumoUsuario(UsuarioExtranet request)
        {
            var resultado = new StatusResponse<IEnumerable<PremioConsumoResponse>>();
            try
            {
                var data = await _uow
                    .ListarPremioConsumoUsuario(request);

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
}
