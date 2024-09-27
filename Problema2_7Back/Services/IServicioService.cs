using Problema2_7Back.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema2_7Back.Services
{
    public interface IServicioService
    {
        void Create(TServicio servicio);

        void Update(TServicio servicio);

        List<TServicio> GetAll();

        TServicio? GetById(int id);
        void Delete(int id);

        List<TServicio> GetByFilter(string promo);
    }
}
