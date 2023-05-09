using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concreate.ViewModels
{
    public class TicketCreateDTO: IViewModel
    {
        public string TicketID { get; set; }
        public string UserId { get;set; } 
        public string FirstName { get;set; }
        public string LastName { get; set; }
        public DateTime DateTime { get; set; }
        public string CityName { get; set; }    
        public string EventName { get; set; }   
        public int EventId { get; set; } 
    }
}
