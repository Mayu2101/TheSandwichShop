using System;

namespace TheSandwichShop.Models.Entities
{
    public class Shift
    {
        public Guid ShiftId { get; set; }
        public DateTime ShiftDate { get; set; }
        public string ShiftType { get; set; }
        public int NoOfEmpBooked { get; set; }
    }
}
