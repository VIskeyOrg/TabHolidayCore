using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TabHolidayCore.Models
{
    public class Transfer
    {
        [Key]
        public int TransferId { get; set; }
        public string City { get; set; }
        public string ShortDescription { get; set; }
        public decimal Rate { get; set; }
        public Int16 DurationHour { get; set; }
        public Int16 DurationMinute { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        
        public Int16 TransferTypeId { get; set; }
        public TransferType TransferType { get; set; }

        public Int16 TransferCategoryId { get; set; }
        public TransferCategory TransferCategory { get; set; }

        public ICollection<VehicleType> VehicleTypes { get; set; }
        public ICollection<TimeSlot> TimeSlots { get; set; }
        public ICollection<BlackOut> BlackOuts { get; set; }
        public ICollection<PremiumDate> PremiumDates { get; set; }



    }
}
