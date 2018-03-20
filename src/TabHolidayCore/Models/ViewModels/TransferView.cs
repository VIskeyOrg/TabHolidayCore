using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TabHolidayCore.Models.ViewModels
{
    public class TransferView
    {
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

        public ICollection<VehicleTypeView> VehicleTypes { get; set; }
        public ICollection<TimeSlotView> TimeSlots { get; set; }
        public ICollection<BlackOutView> BlackOuts { get; set; }
        public ICollection<PremiumDateView> PremiumDates { get; set; }
    }
}
