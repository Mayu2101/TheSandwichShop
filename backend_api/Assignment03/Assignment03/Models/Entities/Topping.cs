using System;

namespace TheSandwichShop.Models.Entities
{
    public class Topping
    {
        public Guid ToppingId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
