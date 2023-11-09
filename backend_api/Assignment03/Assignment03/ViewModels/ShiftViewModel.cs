using System;
using System.Collections.Generic;
using TheSandwichShop.Models.Entities;

namespace TheSandwichShop.ViewModels
{
    public class ShiftViewModel
    {
        public Guid ShiftID { get; set; }
        public DateTime ShiftDate { get; set; }
        public string ShiftType { get; set; }

    }
}
