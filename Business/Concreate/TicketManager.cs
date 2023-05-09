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
    public class TicketManager : ITicketService
    {
        private readonly ITicketDal _ticketDal;
        public TicketManager(ITicketDal ticketDal)
        {
            _ticketDal = ticketDal;
        }

        public void Add(Ticket ticket)
        {
            _ticketDal.Add(ticket);
        }

        public void Delete(Ticket ticket)
        {
            _ticketDal.Delete(ticket);
        }

        public ICollection<Ticket> GetAll()
        {
            return _ticketDal.GetAll();
        }

        public Ticket GetSingleById(string id)
        {
            return _ticketDal.Get(filter:t=>t.TicketID == id); 
        }
        public void Update(Ticket ticket)
        {
            _ticketDal.Update(ticket);
        }
    }
}
