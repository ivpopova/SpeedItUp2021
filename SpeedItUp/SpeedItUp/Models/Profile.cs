using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeedItUp.Models
{
    public class Profile
    {
        public int Id { get; set; }

        public int PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public ICollection<Child> Children { get; set; }
    }
}
