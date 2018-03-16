using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TabHolidayCore.Models
{
    public class PremiumDate
    {
        [Key]
        public int PremiumDateId { get; set; }
        public DateTime PremiumStartDate { get; set; }
        public DateTime PremiumEndDate { get; set; }
        public decimal Rates { get; set; }
    }
}
