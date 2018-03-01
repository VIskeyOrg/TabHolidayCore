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
    public class FacilityController : Controller
    {
        private readonly AppDbContext _context;
        private ReturnClass returnObject = new ReturnClass();

        public FacilityController(AppDbContext context)
        {
            _context = context;

        }

        [HttpGet]
        [Authorize]
        public string Index()
        {
            try
            {

                Facility[] facilities = _context.Facilities.ToArray();
                returnObject.ChangedData = facilities;
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
        public string Add([FromBody]Facility newFacility)
        {
            try
            {
                if (newFacility.FacilityId == 0)
                {
                    _context.Facilities.Add(newFacility);
                }
                else
                {
                    _context.Entry<Facility>(newFacility).State = EntityState.Modified;

                }

                _context.SaveChanges();

                returnObject.ChangedData = newFacility;
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

        [HttpPost]
        [Authorize]
        public string Delete([FromBody]Facility Facility)
        {


            try
            {                
                 _context.Entry<Facility>(Facility).State = EntityState.Deleted;            
                 _context.SaveChanges();
                returnObject.Message = returnObject.GetDeleteMessage();
                returnObject.isSuccess = true;
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

              