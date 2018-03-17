using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TabHolidayCore.Models.ViewModels
{
    public class TimeSlotView
    {
        public Int64 TimeSlotId { get; set; }
        public Int16 StartHour { get; set; }
        public Int16 StartMinute { get; set; }
        public Int16 EndHour { get; set; }
        public Int16 EndMinute { get; set; }

        public bool IsDelete { get; set; }
    }
}
