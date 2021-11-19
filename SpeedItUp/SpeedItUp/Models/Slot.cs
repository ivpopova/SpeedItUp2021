using SpeedItUp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpeedItUp.Models
{
    public class Slot
    {
        public int Id { get; set; }

        public DateTime Time { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public virtual ICollection<Child> Children { get; set; }
        public IEnumerable<Person> Entertainers { get; init; } = new List<Person>();       
    }
}
