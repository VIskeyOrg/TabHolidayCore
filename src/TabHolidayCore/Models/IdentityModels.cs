using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TabHolidayCore.Models
{
    
    public class CustomUserStore : UserStore<ApplicationUser,ApplicationRole,AppDbContext,Int64>
    {
        public CustomUserStore(AppDbContext context)
            : base(context)
        {
        }
    }

    public class CustomRoleStore : RoleStore<ApplicationRole,AppDbContext,Int64>
    {
        public CustomRoleStore(AppDbContext context)
            : base(context)
        {
        }
    }


}
