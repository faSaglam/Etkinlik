using Entitites.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICityService
    {
        ICollection<City> GetAll();
        City GetSingleCity(int id);
        City GetSingleCityByName(string name);

        void Add(City city);
        void Update(City city);
        void Delete(City city);
    }
}
