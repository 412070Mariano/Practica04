using Problema2_7Back.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problema2_7Back.Repositories;

namespace Problema2_7Back.Services
{
    public class ServicioService : IServicioService
    {

        private readonly IServicioRepository _repository;

        public ServicioService(IServicioRepository servicioRepository)
        {
            _repository = servicioRepository;
        }

        public void Create(TServicio servicio)
        {
            _repository.Create(servicio);

        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<TServicio> GetAll()
        {
            return _repository.GetAll();
        }

        public List<TServicio> GetByFilter(string promo)
        {
            return _repository.GetByFilter(promo);
        }

        public TServicio? GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Update(TServicio servicio)
        {
            _repository.Update(servicio);
        }
    }
}
