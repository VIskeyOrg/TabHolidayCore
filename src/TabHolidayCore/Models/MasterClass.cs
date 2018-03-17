using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TabHolidayCore.Models.ViewModels;

namespace TabHolidayCore.Models
{
    public class MasterClass
    {
        public Boolean IsAuthenticated { get; set; }
        public ApplicationUserView User { get; set; }
        public ICollection<Country> Countries { get; set; }
        public ICollection<AgencyTierLevel> AgencyTierLevels { get; set; }
        public ICollection<string> UserRoles { get; set; }
        public ICollection<string> Roles { get; set; }
        public ICollection<Agency> Agencies { get; set; }
        public ICollection<BankAccountType> BankAccountTypes { get; set; }
        public ICollection<DMCOfficialType> DMCOfficialTypes { get; set; }
        public ICollection<Meal> Meals { get; set; }
        public ICollection<StarRating> StarRatings { get; set; }
        public ICollection<SightSeeingCategory> SightSeeingCategories { get; set; }
        public ICollection<InclusionType> InclusionTypes { get; set; }
       
        //public ICollection<TransferCategory> TransferCategories { get; set; }

    }
}
