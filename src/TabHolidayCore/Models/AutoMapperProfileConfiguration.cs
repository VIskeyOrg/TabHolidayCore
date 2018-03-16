using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TabHolidayCore.Models.ViewModels;

namespace TabHolidayCore.Models
{
    public class AutoMapperProfileConfiguration : AutoMapper.Profile
    {
        public AutoMapperProfileConfiguration()
       : this("MyProfile")
        {
        }

        protected AutoMapperProfileConfiguration(string profileName)
        : base(profileName)
        {
            CreateMap<ApplicationUser, ApplicationUserView>();
            CreateMap<ApplicationUserView, ApplicationUser>();

            CreateMap<BlackOut, BlackOutView>();
            CreateMap<BlackOutView, BlackOut>();

            CreateMap<TimeSlot, TimeSlotView>();
            CreateMap<TimeSlotView, TimeSlot>();

            CreateMap<Inclusion, InclusionView>();
            CreateMap<InclusionView, Inclusion>();

            CreateMap<SightSeeing, SightSeeingView>();
            CreateMap<SightSeeingView, SightSeeing>();
        }
    }
}
