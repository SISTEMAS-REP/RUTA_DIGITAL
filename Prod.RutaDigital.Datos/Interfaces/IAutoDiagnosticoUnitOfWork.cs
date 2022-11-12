using Prod.RutaDigital.Entidades;
using Release.Helper.Data.ICore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod.RutaDigital.Datos.Interfaces
{
    public partial interface IUnitOfWork : IBaseUnitOfWork
    {
        Task<AutoDiagnosticoResponse> VerificarAutoDiagnosticoHistorico(int id_usuario_extranet);
        Task<AutoDiagnosticoResponse> VerificarAutoDiagnostico(int id_usuario_extranet);
    }
}
