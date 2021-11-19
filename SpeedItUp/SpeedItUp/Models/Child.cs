using SpeedItUp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpeedItUp.Models
{
    public class Child
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string NickName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [MaxLength(70)]
        public string Notes { get; set; }

        public virtual ICollection<Person> Parents { get; set; }
        public IEnumerable<Slot> Slots { get; init; } = new List<Slot>();
    }
}
