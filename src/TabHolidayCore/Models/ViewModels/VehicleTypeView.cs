using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TabHolidayCore.Models.ViewModels
{
    public class VehicleTypeView
    {
        public Int16 VehicleTypeId { get; set; }
        public string VehicleTypes { get; set; }
        public decimal RatePerHour { get; set; }

        public bool IsDelete { get; set; }
    }
}
