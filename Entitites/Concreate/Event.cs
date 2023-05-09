using Core.Entities;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites.Concreate
{
    public class Event:IEntity
    {
        public int EvenetID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 

        public int Quoto { get; set; }

        public int LeftTickets { get; set; }
        public DateTime DateTime { get; set; }
        public int CategoryID { get; set; } 
        public Category Category { get; set; }

        public int CityID { get; set; } 
        public City City { get; set; }

        public string Id { get; set; } //user
        public User User { get; set; }

        public bool IsConfirmed { get; set; } = false;

        public ICollection<Ticket>? Tickets { get; set; }
    }
}
