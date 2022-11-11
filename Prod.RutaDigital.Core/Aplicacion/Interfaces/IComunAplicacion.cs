using Prod.RutaDigital.Entidades;
using Release.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod.RutaDigital.Core.Aplicacion.Interfaces
{
    public interface IComunAplicacion
    {
        Task<StatusResponse<LoginUnicoResponse>> VerificarAutoDiagnosticoHistorico(LoginUnicoRequest request);
        Task<StatusResponse<LoginUnicoResponse>> VerificarAutoDiagnostico(LoginUnicoRequest request);
    }
}
