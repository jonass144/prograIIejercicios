using Actividad05WebApi.Models;
using Actividad05WebApi.Repositories;

namespace Actividad05WebApi.Services
{
    public class ServicioService : IServicioService
    {
        private readonly IServiciosRepository _service;
        public ServicioService(IServiciosRepository serviciosRepository)
        {
            _service = serviciosRepository;
        }
        public bool BajaLogica(int id)
        {
            return _service.Delete(id);
        }

        public List<TServicio> Get()
        {
            return _service.GetAll();
        }

        public List<TServicio> GetFiltro(string nombre)
        {
            return _service.GetAllFltros(nombre);
        }

        public bool Registrar(TServicio servicio)
        {
           return _service.Save(servicio);
        }

        public bool Update(TServicio servicio, int id)
        {
            return _service.Update(servicio, id);
        }
    }
}
