using System;

namespace TheSandwichShop.Models.Entities
{
    public class ComboItem
    {
        public Guid ComboItemId { get; set; }
        public virtual Guid ItemId { get; set; }
        public virtual Guid ComboId { get; set; }
    }
}
