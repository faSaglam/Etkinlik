using Core.Entities;
using Entitites.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concreate.ViewModels
{
    public class CategoryCreateDTO:IViewModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
     
    }
}
