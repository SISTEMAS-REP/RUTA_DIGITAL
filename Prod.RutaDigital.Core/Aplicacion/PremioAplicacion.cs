using Microsoft.Extensions.Configuration;
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
    public class PremioAplicacion : IPremioAplicacion
    {
        private readonly IPremioUnitOfWork _uow;
        private readonly IConfiguration _configuration;
        public PremioAplicacion(IPremioUnitOfWork premio, IConfiguration configuration)
        {
            this._uow = premio;
            this._configuration = configuration;
        }

        public async Task<StatusResponse<List<PremioPublicidadResponse>>> ListarPublicidadPremio()
        {
            string connectionString = this._configuration.GetSection("fileServer").Value;
            var resultado = new StatusResponse<List<PremioPublicidadResponse>>();
            try
            {
                var data = await _uow
                    .ListarPublicidadPremio();

                foreach (PremioPublicidadResponse x in data)
                {
                    var imagenPath = Path.Combine(connectionString, x.imagen!);
                    x.numArray = File.ReadAllBytes(imagenPath);
                }

                resultado.Success = true;
                resultado.Data = data.ToList();
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

        public async Task<StatusResponse<List<PremioTipoResponse>>> ListarTipoPremio()
        {
            string connectionString = this._configuration.GetSection("fileServer").Value;
            var resultado = new StatusResponse<List<PremioTipoResponse>>();
            try
            {
                var data = await _uow
                    .ListarTipoPremio();

                foreach (PremioTipoResponse x in data)
                {
                    var imagenPath = Path.Combine(connectionString, x.imagen!);
                    x.numArray = File.ReadAllBytes(imagenPath);
                }

                resultado.Success = true;
                resultado.Data = data.ToList();
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

        public async Task<StatusResponse<List<PremioResponse>>> ListarPremio(PremioRequest request)
        {
            string connectionString = this._configuration.GetSection("fileServer").Value;
            var resultado = new StatusResponse<List<PremioResponse>>();
            try
            {
                var data = await _uow
                    .ListarPremio(request);

                foreach (PremioResponse x in data)
                {
                    var imagenPath = Path.Combine(connectionString, x.foto!);
                    x.numArray = File.ReadAllBytes(imagenPath);
                }

                resultado.Success = true;
                resultado.Data = data.ToList();
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

        public async Task<StatusResponse<List<PremioNivelResponse>>> ListarNivelPremio()
        {
            var resultado = new StatusResponse<List<PremioNivelResponse>>();
            try
            {
                var data = await _uow
                    .ListarNivelPremio();

                resultado.Success = true;
                resultado.Data = data.ToList();
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

        public async Task<StatusResponse<List<PremioPuntajeResponse>>> ListarPuntajePremio()
        {
            var resultado = new StatusResponse<List<PremioPuntajeResponse>>();
            try
            {
                var data = await _uow
                    .ListarPuntajePremio();

                resultado.Success = true;
                resultado.Data = data.ToList();
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
