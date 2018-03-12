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
    public class HotelMeal
    {
        [Key]
<<<<<<< HEAD
        public Int16 HotelMealId { get; set; }
        public decimal Price { get; set; }
=======
        public Int64 HotelMealId { get; set; }
        public Decimal Price { get; set; }
>>>>>>> refs/remotes/origin/anjali

        public Int16 MealId { get; set; }
        public Meal Meal { get; set; }
    }
}
