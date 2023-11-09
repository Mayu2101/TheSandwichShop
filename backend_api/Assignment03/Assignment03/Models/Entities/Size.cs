using System;

namespace TheSandwichShop.Models.Entities
{
    public class Size
    {
        public Guid SizeId { get; set; }
        public string Description { get; set; }
        public decimal ExtraCost { get; set; }
    }
}
