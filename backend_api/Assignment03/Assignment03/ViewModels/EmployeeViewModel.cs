using System;

namespace TheSandwichShop.ViewModels
{
    public class EmployeeViewModel
    {
        public Guid EmployeeId { get; set; }
        public string UserName { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public int CellNumber { get; set; }
        public string Email { get; set; }
    }
}
