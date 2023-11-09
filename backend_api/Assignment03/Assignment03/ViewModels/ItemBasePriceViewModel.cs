using System;

namespace TheSandwichShop.ViewModels
{
    public class ItemBasePriceViewModel
    {
        public string ItemBasePriceId { get; set; }
        public string ItemId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
    }
}
