using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TabHolidayCore.Models;
using TabHolidayCore.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using TabHolidayCore.Models.ViewModels.AccountViewModels;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace TabHolidayCore.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        private ReturnClass returnObject = new ReturnClass();

        public AccountController(
           UserManager<ApplicationUser> userManager,
           SignInManager<ApplicationUser> signInManager, AppDbContext context, ILoggerFactory loggerFactory, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [AllowAnonymous]        
        public string Login1([FromBody]LoginViewModel model)
        {
            returnObject.ChangedData = model;
            return returnObject.GetResponse();
        }

        [HttpPost]
        [AllowAnonymous]       
        public async Task<string> Login([FromBody]LoginViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                   // _logger.LogInformation(1, "User logged in.");
                    returnObject.isSuccess = true;

                  var user = await  _userManager.FindByNameAsync(model.Username);
                  var Roles = await _userManager.GetRolesAsync(user);
                  var ChangedData = new { User=_mapper.Map<ApplicationUserView>(user), UserRoles = Roles };
                  returnObject.ChangedData = ChangedData;
                  returnObject.Message = "User logged in.";
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    returnObject.isSuccess = false;
                    returnObject.Message = "Invalid login attempt.";
                }                
               
            }

            // If we got this far, something failed, redisplay form
            return returnObject.GetResponse();
        }

        [HttpPost]        
        public async Task<string> LogOff()
        {
            await _signInManager.SignOutAsync();
            
            return "User logged out.";
        }

        [HttpPost]
        [Authorize]
        public async Task<string> AddUser([FromBody]ApplicationUserView model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.FindByNameAsync(model.UserName);

                    if(user == null)
                    {
                        bool IsAgencyOwner = false;
                       if (model.NewAgency)
                        {
                            Agency newAgency;
                            newAgency = new Agency();
                            newAgency.Name = model.Agency.Name;
                            newAgency.TaxId = model.Agency.TaxId;
                            newAgency.Address = model.Agency.Address;
                            newAgency.AgencyTierLevelId = model.Agency.AgencyTierLevelId;
                            newAgency.CountryId = model.Agency.CountryId;

                            _context.Agencies.Add(newAgency);
                            model.AgencyId = newAgency.AgencyId;
                            IsAgencyOwner = true;
                        }

                        user = new ApplicationUser { UserName = model.UserName, ActualName = model.ActualName, Email = model.Email, AgencyId = model.AgencyId, PhoneNumber = model.PhoneNumber , IsAgencyOwner = IsAgencyOwner };
                        await _userManager.CreateAsync(user, model.Password);

                        await _userManager.AddToRoleAsync(user, model.Role);

                        _context.SaveChanges();
                    }

                    returnObject.isSuccess = true;
                    returnObject.Message = "User created successfully.";
                }
                catch (Exception ex)
                {

                    returnObject.isSuccess = false;
                    returnObject.Message = ex.Message;
                }

            }

            // If we got this far, something failed, redisplay form
            return returnObject.GetResponse();
        }

        [HttpGet]
        [Authorize]
        public string GetUsersCount()
        {
            try
            {
               int userCount = _context.Users.Count();

                returnObject.ChangedData = userCount;
                returnObject.isSuccess = true;

            }
            catch (Exception ex)
            {

                returnObject.isSuccess = false;
                returnObject.Message = ex.Message;
            }

            return returnObject.GetResponse();
        }

        [HttpPost]
        [Authorize]
        public string GetUserList([FromBody]RequestObject requestObject)
        {
            int skip = requestObject.skip;
            int take = requestObject.take;
            string Role = requestObject.Role;

            try
            {
                ApplicationUserView[] usersview;
                ApplicationUser[] users = null;

                if (Role == "All")
                {
                    users = _context.Users.Skip(skip).Take(take).Include(u=>u.Agency).Include(a=>a.Agency.Country).Include(u=>u.Agency.AgencyTierLevel).Include(u=>u.Roles).ToArray();
                   
                }

                usersview = _mapper.Map<ApplicationUserView[]>(users);
                
                returnObject.ChangedData = usersview;
                returnObject.isSuccess = true;
                returnObject.Message = returnObject.GetSaveMessage();
                return returnObject.GetResponse();

            }
            catch (Exception ex)
            {

                returnObject.isSuccess = false;
                returnObject.Message = returnObject.GetErrorMessage(ex);
            }

            return returnObject.GetResponse();
        }

        [HttpPost]
        [Authorize]
        public string CheckUsernameAvailable([FromBody]string Username)
        {
            bool IsUsernameUsed = false;
            try
            {
                IsUsernameUsed = _context.Users.Any(u => u.UserName == Username);

                returnObject.isSuccess = true;
                returnObject.ChangedData = !IsUsernameUsed;
            }
            catch (Exception ex)
            {

                returnObject.isSuccess = false;
                returnObject.GetErrorMessage(ex);
            }

            return returnObject.GetResponse();
        }


        public IActionResult Index()
        {
            return View();
        }
    }

    public class RequestObject
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string Role { get; set; }
    }
}