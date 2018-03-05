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
                
                Hotel[] Hotels = _context.Hotels.Include(s => s.StarRating).ToArray();
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
        public string Add([FromBody]Hotel newHotel)
        {
            try
            {
                if (newHotel.HotelId == 0)
                {
                    _context.Hotels.Add(newHotel);
                }
                else
                {
                    _context.Entry<Hotel>(newHotel).State = EntityState.Modified;

                }

                //_context.Hotels.Add(hotel);
                _context.SaveChanges();
                returnObject.isSuccess = true;
                returnObject.ChangedData = newHotel;
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