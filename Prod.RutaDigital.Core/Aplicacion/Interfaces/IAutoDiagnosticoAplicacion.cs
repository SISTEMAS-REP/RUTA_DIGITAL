using Prod.RutaDigital.Entidades;
using Release.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod.RutaDigital.Core.Aplicacion.Interfaces
{
    public interface IAutoDiagnosticoAplicacion
    {
        Task<StatusResponse<AutoDiagnosticoResponse>> VerificarAutoDiagnosticoHistorico(AutoDiagnosticoRequest request);
        Task<StatusResponse<AutoDiagnosticoResponse>> VerificarAutoDiagnostico(AutoDiagnosticoRequest request);
    }
}
