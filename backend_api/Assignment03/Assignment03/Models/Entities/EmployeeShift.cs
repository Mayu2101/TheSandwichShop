using System;

namespace TheSandwichShop.Models.Entities
{
    public class EmployeeShift
    {
        public Guid EmployeeShiftId { get; set; }
        public virtual string ShiftId { get; set; }
        public virtual string EmployeeId { get; set; }
    }
}
