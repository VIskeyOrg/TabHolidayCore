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
    public class DMCController : Controller
    {
        private readonly AppDbContext _context;
        private ReturnClass returnObject = new ReturnClass();

        public DMCController(AppDbContext context)
        {
            _context = context;

        }

        [HttpPost]
        [Authorize]
        public string Add([FromBody]DMC dmc)
        {
            try
            {

                _context.DMCs.Add(dmc);
                _context.SaveChanges();
                returnObject.isSuccess = true;
                returnObject.ChangedData = dmc;
                returnObject.Message = returnObject.GetSaveMessage();
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
        public string GetDMCs([FromBody]DMC dmc)
        {
            try
            {
                var DMCQuery = _context.DMCs.AsQueryable();

                if (dmc.DMCId > 0)
                {
                    DMCQuery = DMCQuery.Where(d => d.DMCId == dmc.DMCId);
                }

                if (dmc.Name != string.Empty && dmc.Name != null)
                {
                    DMCQuery = DMCQuery.Where(d => d.Name.Contains(dmc.Name));
                }

                if (dmc.CountryId > 0)
                {
                    DMCQuery = DMCQuery.Where(d => d.CountryId == dmc.CountryId);
                }

                if (dmc.OfficeNumber != string.Empty && dmc.OfficeNumber != null)
                {
                    DMCQuery = DMCQuery.Where(d => d.OfficeNumber.Contains(dmc.OfficeNumber));
                }

                returnObject.isSuccess = true;
                returnObject.ChangedData = DMCQuery.Include(d=>d.Country).ToArray();
            }
            catch (Exception ex)
            {

                returnObject.isSuccess = false;
                returnObject.Message = returnObject.GetErrorMessage(ex);
            }
           
            return returnObject.GetResponse();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}