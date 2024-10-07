using Actividad05WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Actividad05WebApi.Repositories
{
    public class TurnoRepository : ITurnoRepository
    {
        private readonly db_turnosContext _context;

        public TurnoRepository(db_turnosContext context)
        {
            _context = context;       
        }
        public bool Delete(int id)
        {
            var turno =  _context.TTurnos.Find(id);
            if (turno != null)
            {
                turno.Fecha = $"CANCELADO{turno.Fecha}";
                _context.TTurnos.Update(turno);
                return  _context.SaveChanges() > 0;
            }
            return false;
        }

        public async Task<TTurno> FindByClientDate(string cliente, string fecha)
        {
            return await _context.TTurnos.FirstOrDefaultAsync(x => x.Cliente.Equals(cliente, StringComparison.CurrentCultureIgnoreCase) &&
           x.Fecha.Equals(fecha));
        }

        public List<TTurno> GetAll()
        {
            return _context.TTurnos.ToList();
        }

        public bool Save(TTurno turno)
        {
            _context.TTurnos.Add(turno);
            return _context.SaveChanges() > 0;
        }

        public bool Update(TTurno turno, int id)
        {
            var turnoactualizado =  _context.TTurnos.Find(id);
            if (turnoactualizado == null) return false;
            turnoactualizado.Cliente = turnoactualizado.Cliente;
            turnoactualizado.Fecha = turnoactualizado.Fecha;
            turnoactualizado.Hora = turnoactualizado.Hora;
            _context.TTurnos.Update(turnoactualizado);
            return _context.SaveChanges() == 1;
        }
    }
}
