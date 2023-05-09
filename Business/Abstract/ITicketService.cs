using Entitites.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITicketService
    {
        ICollection<Ticket> GetAll();
        Ticket GetSingleById(string id);
    
        void Add(Ticket ticket);
        void Update(Ticket ticket);
        void Delete(Ticket ticket);
    }
}
