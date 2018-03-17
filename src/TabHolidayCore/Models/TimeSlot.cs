using System;
using System.ComponentModel.DataAnnotations;

namespace TabHolidayCore.Models
{
   
        public class TimeSlot
        {
            [Key]
            public Int64 TimeSlotId { get; set; }
            public Int16 StartHour { get; set; }
            public Int16 StartMinute { get; set; }
            public Int16 EndHour { get; set; }
            public Int16 EndMinute { get; set; }
        }
    
}

