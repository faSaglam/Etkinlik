using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concreate.ViewModels
{
    public class EventCreateDTO: IViewModel
    {
        public int EvenetID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quoto { get; set; }
        public int LeftTickets { get; set; }
        public DateTime DateTime { get; set; }

        public int CategoryID { get; set; }

        public int CityID { get; set; }
       

    }
}
