using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TabHolidayCore.Models.ViewModels
{
    public class BlackOutView
    {
        public Int64 BlackOutId { get; set; }
        public DateTime BlackOutStartDate { get; set; }
        public DateTime BlackOutEndDate { get; set; }

        public bool IsDelete { get; set; }
    }
}
