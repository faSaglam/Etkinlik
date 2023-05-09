using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concreate.ViewModels
{
    public class UserPasswordUpdateDTO:IViewModel
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
