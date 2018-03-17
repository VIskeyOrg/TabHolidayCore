using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TabHolidayCore.Models
{
    public class VehicleType
    {
        [Key]
        public Int16 VehicleTypeId { get; set; }
        public string VehicleTypes { get; set; }
        public decimal RatePerHour { get; set; }
    }
}
