using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TabHolidayCore.Models
{
    public class BlackOut
    {
        [Key]
        public Int16 BlackOutId { get; set; }
        public DateTime BlackOutStartDate { get; set; }
        public DateTime BlackOutEndDate { get; set; }
    }
}
