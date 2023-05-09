using Core.Entities;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites.Concreate
{
    public class Ticket:IEntity
    {
       
        public string TicketID { get; set; }   
        public Event Event { get; set; }
        public User User { get; set; }
        public string UserName { get; set; }
        public int EventID { get; set; }
    }
}
