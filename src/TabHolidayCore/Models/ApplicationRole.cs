using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace TabHolidayCore.Models
{
    public class ApplicationRole : IdentityRole<Int64>
    {

        public ApplicationRole()
            : base()
        {
           
        }

        public ApplicationRole(string roleName)
        {   
           base.Name = roleName;
        }
    }
}
