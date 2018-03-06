using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TabHolidayCore.Models
{
    public class Hotel
    {
        [Key]
        public Int64 HotelId { get; set; }
        public string Name { get; set; }
        public string TaggedLocation { get; set; }
        public string DetailedLocation { get; set; }
        public string Lattitude { get; set; }
        public string Longitude { get; set; }
        public string EmailId { get; set; }
        public string PhoneNumber { get; set; }
                
        public int StarRatingId { get; set; }
        public StarRating StarRating { get; set; }
               
       public ICollection<HotelFacility> HotelFacilities { get; set; }
       public ICollection<HotelMeal> HotelMeals { get; set; }
    }
}
