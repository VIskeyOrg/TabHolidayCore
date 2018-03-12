using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

<<<<<<< HEAD
=======

>>>>>>> refs/remotes/origin/anjali
namespace TabHolidayCore.Models
{
    public class HotelFacility
    {
        [Key]
<<<<<<< HEAD
        public Int16 HotelFacilityId { get; set; }
        public decimal Price { get; set; }

        public Int16 FacilityId { get; set; }
        public Facility Facility { get; set; }
=======
        public Int64 HotelFacilityId { get; set; }
        public Decimal Price { get; set; }

        public Int16 FacilityId { get; set; }
        public Facility Facility { get; set; }

>>>>>>> refs/remotes/origin/anjali
    }
}
