using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace TabHolidayCore.Models
{
    public class Agency
    {
        [Key]
        public int AgencyId { get; set; }                
        public string Name { get; set; }        
        public string Address { get; set; }        
        public string TaxId { get; set; }

        public int AgencyTierLevelId { get; set; }
        public AgencyTierLevel AgencyTierLevel { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }
        
        

        [JsonIgnore]
        public ICollection<ApplicationUser> ApplicationUsers { get; set; }

    }
}
