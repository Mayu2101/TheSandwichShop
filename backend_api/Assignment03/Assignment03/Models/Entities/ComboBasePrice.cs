using System;

namespace TheSandwichShop.Models.Entities
{
    public class ComboBasePrice
    {
        public Guid ComboBasePriceId { get; set; }
        public Guid ComboId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
    }
}
