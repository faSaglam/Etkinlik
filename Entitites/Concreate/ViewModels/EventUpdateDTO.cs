using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concreate.ViewModels
{
    public class EventUpdateDTO:IViewModel
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public DateTime DateTime { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public string CityName { get; set; }    

        public int Quoto { get; set; }
        public int LeftTickets { get; set; }

        public int CategoryID { get; set; } 
        public int CityID { get; set; }
    }
}
