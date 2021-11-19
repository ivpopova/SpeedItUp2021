using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeedItUp.Models
{
    public class AddToSlotViewModel
    {
        public int SlotID { get; set; }

        public DateTime Date { get; set; }

        public IEnumerable<Child> Children { get; init; } = new List<Child>();
    }

    public class AddToSlotFormModel
    {
        public IEnumerable<int> ChildIDs { get; init; } = new List<int>();
        public int SlotID { get; set; }
    }

}

