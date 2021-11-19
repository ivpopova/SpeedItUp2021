using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeedItUp.Models
{
    public class PersonViewModel
    {
            public string FullName { get; set; }
            public ICollection<Child> Children { get; set; }    
    }
}

