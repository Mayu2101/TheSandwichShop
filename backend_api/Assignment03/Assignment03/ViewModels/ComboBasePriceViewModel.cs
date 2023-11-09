using System;

namespace TheSandwichShop.ViewModels
{
    public class ComboBasePriceViewModel
    {
        public string ComboBasePriceId { get; set; }
        public string ComboId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
    }
}
