using Actividad05WebApi.Models;

namespace Actividad05WebApi.Repositories
{
    public interface ITurnoRepository
    {
        List<TTurno> GetAll();
        bool Save(TTurno turno);
        bool Update(TTurno turno, int id);
        bool Delete(int id);

        Task<TTurno> FindByClientDate(string cliente, string fecha);

    }
}
