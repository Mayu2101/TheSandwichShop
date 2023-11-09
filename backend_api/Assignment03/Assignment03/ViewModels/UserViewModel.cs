using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheSandwichShop.ViewModels
{
    public class UserViewModel
    {
        public string userName { get; set; }
        public string otp { get; set; }
        public string employeeId { get; set;}
        public string userId { get; set; }
        public bool hasBookedShift { get; set; }
    }
}
