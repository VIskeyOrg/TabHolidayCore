using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TabHolidayCore.Models;

namespace TabHolidayCore.Models.ViewModels
{
    public class ApplicationUserView
    {

        public Int64 Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string ActualName { get; set; }
        public int? AgencyId { get; set; }
        public Agency Agency { get; set; }
        public string Role { get; set; }
        public ICollection<IdentityUserRole<long>> Roles { get; set; }

        public bool NewAgency { get; set; }

        
    }
}
