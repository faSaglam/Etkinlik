using Business.Abstract;
using DataAccess.Abstract;
using Entitites.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class CityManager : ICityService
    {
        private readonly ICityDal _cityDal;
        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }
        public void Add(City city)
        {
            _cityDal.Add(city);
        }

        public void Delete(City city)
        {
           _cityDal.Delete(city);
        }

        public ICollection<City> GetAll()
        {
            return _cityDal.GetAll();   
        }

        public City GetSingleCityByName(string name)
        {
            return _cityDal.Get(filter: c => c.Name == name);
        }

        public City GetSingleCity(int id)
        {
            return _cityDal.Get(filter: c => c.CityID == id);
        }
        
        public void Update(City city)
        {
            _cityDal.Update(city);
        }
    }
}
