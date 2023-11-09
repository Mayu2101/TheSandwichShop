using System;

namespace TheSandwichShop.Models.Entities
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public virtual Guid EmployeeId { get; set; }
        public string OrderNotes { get; set; }
    }
}
