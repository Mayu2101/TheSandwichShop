using System;

namespace TheSandwichShop.Models.Entities
{
    public class ItemSize
    {
        public Guid ItemSizeId { get; set; }
        public virtual Guid ItemId { get; set; }
        public virtual Guid SizeId { get; set; }
    }
}
