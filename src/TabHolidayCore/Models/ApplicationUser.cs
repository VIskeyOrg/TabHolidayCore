using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace TabHolidayCore.Models
{
    public class ApplicationUser: IdentityUser<Int64>
    {
        
        public string ActualName { get; set; }
        public bool IsAgencyOwner { get; set; }

        public int? AgencyId { get; set; }

        [JsonIgnore]
        public Agency Agency { get; set; }

        
    }
}
