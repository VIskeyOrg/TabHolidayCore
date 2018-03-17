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
    public class SightSeeingController : Controller
    {
        private readonly AppDbContext _context;
        private ReturnClass returnObject = new ReturnClass();

        public SightSeeingController(AppDbContext context)
        {
            _context = context;

        }

        [HttpGet]
        [Authorize]
        public string Index()
        {
            try
            {
                SightSeeing[] SightSeeings = _context.SightSeeings.Include(s => s.StarRating).Include(a => a.SightSeeingCategory).ToArray();
                returnObject.ChangedData = SightSeeings;
                returnObject.isSuccess = true;
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
        public string Add([FromBody]SightSeeing newSightSeeing)
        {
            try
            {
                if (newSightSeeing.SightSeeingId == 0)
                {
                    _context.SightSeeings.Add(newSightSeeing);
                }
                else
                {
                    _context.Entry<SightSeeing>(newSightSeeing).State = EntityState.Modified;

                }

                _context.SaveChanges();
                returnObject.ChangedData = newSightSeeing;
                returnObject.isSuccess = true;
                returnObject.Message = returnObject.GetSaveMessage();
            }
            catch (Exception ex)
            {
                returnObject.isSuccess = false;
                returnObject.Message = returnObject.GetErrorMessage(ex);

            }
            return returnObject.GetResponse();
        }
    }
}