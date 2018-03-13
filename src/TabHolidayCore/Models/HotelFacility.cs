﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;




namespace TabHolidayCore.Models
{
    public class HotelFacility
    {
        [Key]

        public Int16 HotelFacilityId { get; set; }
        public decimal Price { get; set; }

        public Int16 FacilityId { get; set; }
        public Facility Facility { get; set; }

       


    }
}
