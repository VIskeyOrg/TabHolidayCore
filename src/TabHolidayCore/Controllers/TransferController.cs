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
    public class TransferController : Controller
    {

        private readonly AppDbContext _context;
        private ReturnClass returnObject = new ReturnClass();

        public TransferController(AppDbContext context)
        {
            _context = context;

        }

        [HttpGet]
        [Authorize]
        public string Index()
        {
            try
            {
                Transfer[] Transfers = _context.Transfers.Include(s => s.TransferType).Include(a => a.TransferCategory).Include(t=>t.BlackOuts).Include(t => t.TimeSlots).Include(p => p.VehicleTypes).Include(a => a.PremiumDates).ToArray();
                returnObject.ChangedData = Transfers;
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
        public string Add([FromBody]Transfer newTransfer)
        {
            try
            {
                if (newTransfer.TransferId == 0)
                {

                    _context.Transfers.Add(newTransfer);
                }
                else
                {
                    _context.Entry<Transfer>(newTransfer).State = EntityState.Modified;

                }

                _context.SaveChanges();
                returnObject.ChangedData = newTransfer;
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