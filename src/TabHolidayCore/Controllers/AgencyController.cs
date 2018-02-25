using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TabHolidayCore.Models;
using Microsoft.EntityFrameworkCore;

namespace TabHolidayCore.Controllers
{
    public class AgencyController : Controller
    {
        private readonly AppDbContext _context;
        private ReturnClass returnObject = new ReturnClass();

        public AgencyController(AppDbContext context)
        {
            _context = context;
           
        }

        [HttpGet] 
        [Authorize]       
        public string Index()
        {
            Agency[] agencies;
            try
            {
                agencies = _context.Agencies.Include(a=>a.Country).Include(b=>b.AgencyTierLevel).ToArray();
                returnObject.ChangedData = agencies;
                returnObject.isSuccess = true;
            }
            catch (Exception ex)
            {
                returnObject.isSuccess = false;
                returnObject.GetErrorMessage(ex);
                
            }

            return returnObject.GetResponse();
        }



        [HttpPost]
        [Authorize]
        public string Add([FromBody]Agency agency)
        {
            try
            {
                if(agency.AgencyId == 0 )
                {
                    _context.Agencies.Add(agency);
                }
                else
                {
                    _context.Entry<Agency>(agency).State = EntityState.Modified;
                }
               
                _context.SaveChanges();

                returnObject.ChangedData = agency;
                returnObject.isSuccess = true;
                returnObject.Message = returnObject.GetSaveMessage();
            }
            catch (Exception ex)
            {

                returnObject.GetErrorMessage(ex);
                returnObject.isSuccess = false;
            }
            

            return returnObject.GetResponse();
        }
    }
}