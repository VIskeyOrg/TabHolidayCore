using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TabHolidayCore.Models.ViewModels
{
    public class PremiumDateView
    {
        public int PremiumDateId { get; set; }
        public DateTime PremiumStartDate { get; set; }
        public DateTime PremiumEndDate { get; set; }
        public decimal Rates { get; set; }

        public bool IsDelete { get; set; }
    }
}
