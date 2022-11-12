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
    public class AutoDiagnosticoAplicacion : IAutoDiagnosticoAplicacion
    {
        private readonly IUnitOfWork _uow;
        public AutoDiagnosticoAplicacion(IUnitOfWork uow)
        {
            this._uow = uow;
        }

        public async Task<StatusResponse<AutoDiagnosticoResponse>> VerificarAutoDiagnosticoHistorico(AutoDiagnosticoRequest request)
        {
            var resultado = new StatusResponse<AutoDiagnosticoResponse>();

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

        public async Task<StatusResponse<AutoDiagnosticoResponse>> VerificarAutoDiagnostico(AutoDiagnosticoRequest request)
        {
            var resultado = new StatusResponse<AutoDiagnosticoResponse>();

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
