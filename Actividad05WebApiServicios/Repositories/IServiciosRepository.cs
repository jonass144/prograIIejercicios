using Actividad05WebApi.Models;

namespace Actividad05WebApi.Repositories
{
    public interface IServiciosRepository
    {
        bool Save(TServicio servicio);

        bool Delete(int id);

        List<TServicio> GetAll();

        bool Update(TServicio servicio, int id);

        List<TServicio> GetAllFltros(string nombre);
    }
}
