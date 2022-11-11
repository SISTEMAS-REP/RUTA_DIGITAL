using Prod.RutaDigital.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod.RutaDigital.Datos.Interfaces
{
    public interface IComunUnitOfWork
    {
        Task<LoginUnicoResponse> VerificarAutoDiagnosticoHistorico(int id_usuario_extranet);
        Task<LoginUnicoResponse> VerificarAutoDiagnostico(int id_usuario_extranet);
    }
}
