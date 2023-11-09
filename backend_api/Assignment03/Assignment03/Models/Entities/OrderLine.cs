using System;

namespace TheSandwichShop.Models.Entities
{
    public class OrderLine
    {
        public Guid OrderLineId { get; set; }
        public virtual Guid OrderId { get; set; }
        public virtual Guid ItemId { get; set; }
        public decimal OrderLinePrice {  get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
