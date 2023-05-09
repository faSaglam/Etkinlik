using Core.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concreate.ViewModels
{
    public class UserProfileDTO:IViewModel
    {
        public string UserName { get; set; }    
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        
    }
}
