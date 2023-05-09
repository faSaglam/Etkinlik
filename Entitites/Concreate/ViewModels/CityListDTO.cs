using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concreate.ViewModels
{
    public class CityListDTO:IViewModel
    {
        public string Name { get; set; }
        public int CityID { get; set; }
    }
}
