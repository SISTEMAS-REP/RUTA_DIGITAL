using Release.Helper;

using Prod.RutaDigital.Core.Aplicacion.Interfaces;
using Prod.RutaDigital.Datos.Interfaces;
using Prod.RutaDigital.Entidades;

namespace Prod.RutaDigital.Core.Aplicacion;

public class PremioAplicacion : IPremioAplicacion
{
    private readonly IUnitOfWork _uow;

    public PremioAplicacion(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<StatusResponse<IEnumerable<PremioResponse>>>
        ListarPremios(PremioRequest request)
    {
        var resultado = new StatusResponse<IEnumerable<PremioResponse>>();

        try
        {
            var data = await _uow
                .ListarPremios(request);

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

    public async Task<StatusResponse<IEnumerable<Premio>>>
        ListarPuntajesPremios()
    {
        var resultado = new StatusResponse<IEnumerable<Premio>>();

        try
        {
            var data = await _uow
                .ListarPuntajesPremios();

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


    public async Task<StatusResponse<PremioCanjeResponse>> CanjePremio(PremioCanjeRequest request)
    {
        var resultado = new StatusResponse<PremioCanjeResponse>();
        try
        {
            var data = await _uow
                .CanjePremio(request);

            resultado.Success = true;
            resultado.Data = data;
        }
        catch (Exception ex)
        {
            resultado.Success = false;
            resultado.Messages = new()
            {
                ex.Message
            };
        }

        return resultado;
    }


    /*
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

    public async Task<StatusResponse<List<Premio>>> ListarPremio()
    {
        string connectionString = this._configuration.GetSection("fileServer").Value;
        var resultado = new StatusResponse<List<Premio>>();
        try
        {
            var data = await _uow
                .ListarPremio();

            foreach (Premio x in data)
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
    }*/
}
