using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;
using Release.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod.RutaDigital.Core.Aplicacion
{
    public class ComunAplicacion : IComunAplicacion
    {
        private readonly IComunUnitOfWork _uow;
        public ComunAplicacion(IComunUnitOfWork bannerUnitOfWork)
        {
            this._uow = bannerUnitOfWork;
        }

        public async Task<StatusResponse<LoginUnicoResponse>> VerificarAutoDiagnosticoHistorico(LoginUnicoRequest request)
        {
            var resultado = new StatusResponse<LoginUnicoResponse>();

            try
            {
                var data = await _uow.VerificarAutoDiagnosticoHistorico(request.id_usuario_extranet);

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

        public async Task<StatusResponse<LoginUnicoResponse>> VerificarAutoDiagnostico(LoginUnicoRequest request)
        {
            var resultado = new StatusResponse<LoginUnicoResponse>();

            try
            {
                var data = await _uow.VerificarAutoDiagnostico(request.id_usuario_extranet);

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
