using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TabHolidayCore.Models
{
    public class Menu
    {
        [Key]
        public Int16 MenuId { get; set; }
        public string Description { get; set; }
    }
}
