using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;


namespace TabHolidayCore.Models
{
    public class State
    {
        [Key]
        public Int64 StateId { get; set; }

        public string Name { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
