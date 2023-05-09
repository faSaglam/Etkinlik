using Core.Entities;
using Entitites.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concreate.ViewModels
{
    public class TicketListDTO:IViewModel
    {
        public string TicketID { get; set; }   
        public Entitites.Concreate.Event Event { get; set; }
        public User User { get; set; }
        public City City { get; set; }
        public int CityID { get; set; }
        public string UserId { get; set; }

        public DateTime DateTime { get; set; }
        public string CityName { get; set; }
        public string EventName { get; set; }
        public int EventId { get; set; }
    }
}
