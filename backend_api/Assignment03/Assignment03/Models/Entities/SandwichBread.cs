using System;

namespace TheSandwichShop.Models.Entities
{
    public class SandwichBread
    {
        public Guid SandwichBreadId { get; set; }
        public virtual Guid SandwichId { get; set; }
        public virtual Guid BreadTypeId { get; set; }

    }
}
