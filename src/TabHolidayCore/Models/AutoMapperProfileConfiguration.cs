﻿using System;
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

            //DMC mapping
            CreateMap<BankDetail, BankDetailView>();
            CreateMap<BankDetailView, BankDetail>();
            CreateMap<DMCOfficial, DMCOfficialView>();
            CreateMap<DMCOfficialView, DMCOfficial>();
            CreateMap<DMC, DMCView>();
            CreateMap<DMCView, DMC>();
           
        }
    }
}
