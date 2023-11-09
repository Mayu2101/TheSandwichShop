using System;

namespace TheSandwichShop.Models.Entities
{
    public class ItemBasePrice
    {
        public Guid ItemBasePriceId { get; set; }
        public Guid ItemId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
    }
}
