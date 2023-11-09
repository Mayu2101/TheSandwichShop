using System;

namespace TheSandwichShop.Models.Entities
{
    public class SandwichTopping
    {
        public Guid SandwichToppingId { get; set; }
        public virtual Guid SandwichId { get; set; }
        public virtual Guid ToppingId { get; set; }
    }
}
