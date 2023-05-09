using Entitites.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEventService
    {
        ICollection<Event> GetAll();
        Event GetSingleById(int id);
        Event GetSingleByName(string name);

        ICollection<Event> GetByCategoryID(int categoryID);
        ICollection<Event> GetByCityID(int cityID);


        void Add(Event @event);
        void Update(Event @event);
        void Delete(Event @event);    


    }
}
