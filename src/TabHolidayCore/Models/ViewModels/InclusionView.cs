using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TabHolidayCore.Models.ViewModels
{
    public class InclusionView
    {
        public Int64 InclusionId { get; set; }
        public Int16 DurationHour { get; set; }
        public Int16 DurationMinute { get; set; }

        public string Inclusions { get; set; }

        public Int16 InclusionTypeId { get; set; }
        public InclusionType InclusionType { get; set; }

        public bool IsDelete { get; set; }
    }
}
