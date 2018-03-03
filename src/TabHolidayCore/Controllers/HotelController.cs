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
    public class HotelController : Controller
    {

        private readonly AppDbContext _context;
        private ReturnClass returnObject = new ReturnClass();

        public HotelController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize]
        public string Index()
        {
            try
            {

                Hotel[] Hotels = _context.Hotels.ToArray();
                returnObject.ChangedData = Hotels;
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
        public string Add([FromBody]Hotel hotel)
        {
            try
            {

                _context.Hotels.Add(hotel);
                _context.SaveChanges();
                returnObject.isSuccess = true;
                returnObject.ChangedData = hotel;
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