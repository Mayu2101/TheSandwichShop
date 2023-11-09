using System;

namespace TheSandwichShop.ViewModels
{
    public class EmpShiftListViewModel
    {
        public string EmployeeShiftId { get; set; }
        public string EmployeeId { get; set; }
        public string ShiftType { get; set; }
        public DateTime ShiftDate { get; set; }
    }
}
