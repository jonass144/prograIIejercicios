using Actividad05WebApi.Models;

namespace Actividad05WebApi.Repositories
{
    public class ServicioRepository : IServiciosRepository
    {

        private readonly db_turnosContext _context;
        public ServicioRepository(db_turnosContext context)
        {
             _context = context;
        }

        public bool Delete(int id)
        {
            var servicio = _context.TServicios.Find(id);
            if(servicio != null)
            {
                servicio.Nombre = $"ELIMINADO_{servicio.Nombre}";
                _context.TServicios.Update(servicio);
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public List<TServicio> GetAll()
        {
            return _context.TServicios.ToList();
        }

        public List<TServicio> GetAllFltros(string nombre)
        {
            return _context.TServicios.Where(p => p.Nombre.Contains(nombre)).ToList();
        }

        public bool Save(TServicio servicio)
        {
            _context.TServicios.Add(servicio);
            return _context.SaveChanges() > 0;
        }

        public bool Update(TServicio servicio, int id)
        {
            var entity = _context.TServicios.Find(id);
            if(entity == null) return false;
            entity.Nombre = servicio.Nombre;
            entity.Costo = servicio.Costo;
            entity.EnPromocion = servicio.EnPromocion;
            _context.TServicios.Update(entity);
            return _context.SaveChanges() > 0;
        }
    }
}
