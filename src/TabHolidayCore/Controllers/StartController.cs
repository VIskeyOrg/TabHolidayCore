using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using TabHolidayCore.Models;
using TabHolidayCore.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace TabHolidayCore.Controllers
{
    public class StartController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private ReturnClass returnObject = new ReturnClass();
        private readonly IMapper _mapper;

        public StartController(AppDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        public string Index()
        {
            ApplicationUser appuser;

            try
            {
                MasterClass master = new MasterClass();

                if (User.Identity.IsAuthenticated)
                {
                    appuser = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                    master.IsAuthenticated = true;
                    master.User = _mapper.Map<ApplicationUserView>(appuser);
                    master.UserRoles = _userManager.GetRolesAsync(appuser).Result;
                }
                else
                {
                    master.IsAuthenticated = false;
                }
                master.Countries = _context.Countries.ToArray();
                master.AgencyTierLevels = _context.AgencyTierLevels.ToArray();
                master.Roles = _context.Roles.Select(r => r.Name).ToArray();
                master.Agencies = _context.Agencies.ToArray();
                master.DMCOfficialTypes = _context.DMCOfficialTypes.ToArray();
                master.BankAccountTypes = _context.BankAccountTypes.ToArray();
                master.Meals = _context.Meals.ToArray();
                master.StarRatings = _context.StarRatings.ToArray();
                master.SightSeeingCategories = _context.SightSeeingCategories.ToArray();
                master.InclusionTypes = _context.InclusionTypes.ToArray();
                master.TransferTypes = _context.TransferTypes.ToArray();
                master.TransferCategories = _context.TransferCategories.ToArray();
                master.FoodTypes = _context.FoodTypes.ToArray();
                master.RestaurantTypes = _context.RestaurantTypes.ToArray();

                returnObject.ChangedData = master;
                returnObject.isSuccess = true;
                returnObject.Message = "";
                return returnObject.GetResponse();

            }
            catch (Exception ex)
            {


                returnObject.isSuccess = false;
                returnObject.Message = returnObject.GetErrorMessage(ex);
                return returnObject.GetResponse();
            }
        }


    }
}