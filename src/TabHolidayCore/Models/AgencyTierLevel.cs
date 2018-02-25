using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace TabHolidayCore.Models 
{
    public class AgencyTierLevel
    {
        [Key]
        public int AgencyTierLevelId { get; set; }       
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Agency> Agencies { get; set; }
    }
}
