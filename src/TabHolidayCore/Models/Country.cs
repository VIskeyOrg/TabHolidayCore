using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;


namespace TabHolidayCore.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }              
        public string Name { get; set; }        
        public string Extention { get; set; }

        [JsonIgnore]
        public ICollection<Agency> Agencies { get; set; }
    }
}
