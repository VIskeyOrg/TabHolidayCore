using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TabHolidayCore.Models
{
    public class RestaurantType
    {
        [Key]
        public Int16 RestaurantTypeId { get; set; }
        public string Name { get; set; }
    }
}
