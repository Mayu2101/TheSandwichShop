using System;

namespace TheSandwichShop.Models.Entities
{
    public class Item
    {
        public Guid ItemId { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
    }
}
