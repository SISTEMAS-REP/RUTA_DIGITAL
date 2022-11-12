﻿using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;
using Release.Helper.Data.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod.RutaDigital.Datos
{
    public partial class UnitOfWork : IUnitOfWork
    {
        public async Task<AutoDiagnosticoResponse> VerificarAutoDiagnosticoHistorico(int id_usuario_extranet)
        {
            var para = new Parameter[]
            {
                new Parameter("@id_usuario_extranet", id_usuario_extranet)
            };
            var result = ExecuteReader<AutoDiagnosticoResponse>("USP_VERIFICAR_AUTODIAGNOSTICO_HISTORICO",
                CommandType.StoredProcedure, ref para).FirstOrDefault();
            return await Task.FromResult(result);
        }

        public async Task<AutoDiagnosticoResponse> VerificarAutoDiagnostico(int id_usuario_extranet)
        {
            var para = new Parameter[]
            {
                new Parameter("@id_usuario_extranet", id_usuario_extranet)
            };
            var result = this.ExecuteReader<AutoDiagnosticoResponse>("USP_VERIFICAR_AUTODIAGNOSTICO",
                CommandType.StoredProcedure, ref para).FirstOrDefault();
            return await Task.FromResult(result);
        }
    }
}
