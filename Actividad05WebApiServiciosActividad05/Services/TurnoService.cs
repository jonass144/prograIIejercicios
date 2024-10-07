using Actividad05WebApi.Models;
using Actividad05WebApi.Repositories;

namespace Actividad05WebApi.Services
{
    public class TurnoService : ITurnoService
    {
        private readonly ITurnoRepository _repository;

        public TurnoService(ITurnoRepository repository)
        {
            _repository = repository;
        }
        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public async Task<TTurno> FindByClientDate(string cliente, string fecha)
        {
            return await _repository.FindByClientDate(cliente, fecha);
        }

        public List<TTurno> GetAll()
        {
            return _repository.GetAll();
        }

        public bool Save(TTurno turno)
        {
            return _repository.Save(turno);
        }

        public bool Update(TTurno turno, int id)
        {
            return _repository.Update(turno, id);
        }
    }
}
