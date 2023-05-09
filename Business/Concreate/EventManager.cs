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
    public class EventManager:IEventService
    {
        public readonly IEventDal _eventDal;
        public EventManager(IEventDal eventDal)
        {
            _eventDal = eventDal;
        }

        public void Add(Event @event)
        {
            _eventDal.Add(@event);
        }

        public void Delete(Event @event)
        {
            _eventDal.Delete(@event);
        }

        public ICollection<Event> GetAll()
        {
            return _eventDal.GetAll(includes: e =>e.City);
        }

        public ICollection<Event> GetByCategoryID(int categoryID)
        {
            return _eventDal.GetAll(filter: e => e.CategoryID == categoryID, includes:e=>e.City);
        }

        public ICollection<Event> GetByCityID(int cityID)
        {
            return _eventDal.GetAll(filter: e => e.CityID == cityID, includes: e => e.City);
        }

        public Event GetSingleById(int id)
        {
            return _eventDal.Get(filter: e => e.EvenetID == id);
        }

        public Event GetSingleByName(string name)
        {
           return _eventDal.Get(filter:e=>e.Name == name);  
        }

 

        public void Update(Event @event)
        {
            _eventDal.Update(@event);
        }
    }
}
