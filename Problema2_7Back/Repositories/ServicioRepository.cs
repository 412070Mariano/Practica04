using Problema2_7Back.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema2_7Back.Repositories
{
    public class ServicioRepository : IServicioRepository
    {
        private TurnosDbContext _context;

        public ServicioRepository(TurnosDbContext context)
        {
            _context = context;
        }

        /*public void SetContext(TurnosDbContext context)
        {
            _context = context;
        }*/

        public void Create(TServicio servicio)
        {
            _context.TServicios.Add(servicio);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var ServicioDeleted = GetById(id);
            if (ServicioDeleted != null)
            {
                _context.TServicios.Remove(ServicioDeleted);
                _context.SaveChanges();
            }
        }

        public List<TServicio> GetAll()
        {
            return _context.TServicios.ToList();
        }

        //CON FILTROS
        public List<TServicio> GetByFilter(string promo)
        {
            return _context.TServicios.Where(X => X.EnPromocion == promo).ToList();
        }



        public TServicio? GetById(int id)
        {
            return _context.TServicios.Find(id);
        }

        public void Update(TServicio servicio)
        {
            if (servicio != null)
            { 
                _context.TServicios.Update(servicio);
                _context.SaveChanges();
            }
        }


    }
}
