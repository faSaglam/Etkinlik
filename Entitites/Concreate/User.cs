using Core.Entities;
using Entitites.Concreate;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concreate
{
    public class User: IdentityUser, IEntity
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Ticket>? Tickets { get; set; }
        public ICollection<Event>? Events { get; set; }
       
    }
}
