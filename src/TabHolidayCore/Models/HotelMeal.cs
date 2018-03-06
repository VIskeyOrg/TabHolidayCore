using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TabHolidayCore.Models
{
    public class HotelMeal
    {
        [Key]
        public Int64 HotelMealId { get; set; }
        public Decimal Price { get; set; }

        public Int16 MealId { get; set; }
        public Meal Meal { get; set; }
    }
}
