using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concreate.ViewModels
{
    public class CategoryListDTO:IViewModel
    {
        public string CategoryName { get; set; }
        public int CategoryID { get; set; } 
    }
}
