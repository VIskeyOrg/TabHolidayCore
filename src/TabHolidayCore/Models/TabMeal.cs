using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TabHolidayCore.Models
{
    public class TabMeal
    {
        [Key]
        public int TabMealId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public Int16 OpeningHour { get; set; }
        public Int16 OpeningMinute { get; set; }
        public Int16 ClosingHour { get; set; }
        public Int16 ClosingMinute { get; set; }
        public string MenuDescription { get; set; }
        public bool Breakfast { get; set; }
        public bool Lunch { get; set; }
        public bool Dinner { get; set; }
        public decimal BreakfastRate { get; set; }
        public decimal LunchRate { get; set; }
        public decimal DinnerRate { get; set; }

        public Int16 FoodTypeId { get; set; }
        public FoodType FoodType { get; set; }

        public Int16 RestaurantTypeId { get; set; }
        public RestaurantType RestaurantType { get; set; }

        
    }
}
