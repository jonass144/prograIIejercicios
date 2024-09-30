using Actividad05WebApi.Models;

namespace Actividad05WebApi.Services
{
    public interface IServicioService
    {
        bool Registrar(TServicio servicio);
        bool BajaLogica( int id);
        bool Update(TServicio servicio, int id);
        List<TServicio> Get();
        
        List<TServicio> GetFiltro(string nombre);

    }
}
