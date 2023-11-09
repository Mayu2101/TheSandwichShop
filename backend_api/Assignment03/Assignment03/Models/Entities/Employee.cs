using System;

namespace TheSandwichShop.Models.Entities
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        public string UserId { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public int CellNumber { get; set; }
        public string Email { get; set; }
    }
}
