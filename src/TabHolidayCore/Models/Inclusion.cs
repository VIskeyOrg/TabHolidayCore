using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TabHolidayCore.Models
{
    public class Inclusion
    {
        [Key]
        public Int64 InclusionId { get; set; }
        public Int16 DurationHour { get; set; }
        public Int16 DurationMinute { get; set; }

        public string Inclusions { get; set; }

        public Int16 InclusionTypeId { get; set; }
        public InclusionType InclusionType { get; set; }



    }
}
