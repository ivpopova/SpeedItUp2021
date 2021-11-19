using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SpeedItUp.Models
{
    public class Person : IdentityUser
    {
        public string FullName { get; set; }
        public virtual ICollection<Child> Children { get; set; }
        public ICollection<Slot> Slots { get; set; }
    }
}
