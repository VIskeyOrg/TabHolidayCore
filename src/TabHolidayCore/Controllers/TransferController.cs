using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TabHolidayCore.Models;
using TabHolidayCore.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace TabHolidayCore.Controllers
{
    public class TransferController : Controller
    {

        private readonly AppDbContext _context;
        private ReturnClass returnObject = new ReturnClass();
        private readonly IMapper _mapper;

        public TransferController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

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

        [HttpPost]
        [Authorize]
        public string Edit([FromBody]TransferView transferView)
        {
            try
            {
                List<VehicleTypeView> deletedVehicleTypeViews = new List<VehicleTypeView>();
                List<PremiumDateView> deletedPremiumDateViews = new List<PremiumDateView>();
                List<BlackOutView> deletedBlackOutViews = new List<BlackOutView>();
                List<TimeSlotView> deletedTimeSlotViews = new List<TimeSlotView>();

                foreach (BlackOutView deletedBlackOutView in transferView.BlackOuts)
                {
                    if (deletedBlackOutView.IsDelete)
                    {
                        deletedBlackOutViews.Add(deletedBlackOutView);
                    }
                }

                foreach (PremiumDateView deletedPremiumDateView in transferView.PremiumDates)
                {
                    if (deletedPremiumDateView.IsDelete)
                    {
                        deletedPremiumDateViews.Add(deletedPremiumDateView);
                    }
                }

                foreach (VehicleTypeView deletedVehicleTypeView in transferView.VehicleTypes)
                {
                    if (deletedVehicleTypeView.IsDelete)
                    {
                        deletedVehicleTypeViews.Add(deletedVehicleTypeView);
                    }
                }

                foreach (TimeSlotView deletedTimeSlotView in transferView.TimeSlots)
                {
                    if (deletedTimeSlotView.IsDelete)
                    {
                        deletedTimeSlotViews.Add(deletedTimeSlotView);
                    }
                }

                for (int i = transferView.TimeSlots.Count; i > 0; i--)
                {
                    if (transferView.TimeSlots.ElementAt(i - 1).IsDelete)
                    {
                        transferView.TimeSlots.Remove(transferView.TimeSlots.ElementAt(i - 1));
                    }
                }

                for (int i = transferView.BlackOuts.Count; i > 0; i--)
                {
                    if (transferView.BlackOuts.ElementAt(i - 1).IsDelete)
                    {
                        transferView.BlackOuts.Remove(transferView.BlackOuts.ElementAt(i - 1));
                    }
                }

                for (int i = transferView.VehicleTypes.Count; i > 0; i--)
                {
                    if (transferView.VehicleTypes.ElementAt(i - 1).IsDelete)
                    {
                        transferView.VehicleTypes.Remove(transferView.VehicleTypes.ElementAt(i - 1));
                    }
                }

                for (int i = transferView.PremiumDates.Count; i > 0; i--)
                {
                    if (transferView.PremiumDates.ElementAt(i - 1).IsDelete)
                    {
                        transferView.PremiumDates.Remove(transferView.PremiumDates.ElementAt(i - 1));
                    }
                }

                Transfer transfer = _mapper.Map<Transfer>(transferView);

                List<BlackOut> DeletedBlackOuts = new List<BlackOut>();
                List<TimeSlot> DeletedTimeSlots = new List<TimeSlot>();
                List<PremiumDate> DeletedPremiumDates = new List<PremiumDate>();
                List<VehicleType> DeletedVehicleTypes = new List<VehicleType>();

                
                DeletedBlackOuts = _mapper.Map<List<BlackOut>>(deletedBlackOutViews);
                DeletedTimeSlots = _mapper.Map<List<TimeSlot>>(deletedTimeSlotViews);
                DeletedPremiumDates = _mapper.Map<List<PremiumDate>>(deletedPremiumDateViews);
                DeletedVehicleTypes = _mapper.Map<List<VehicleType>>(deletedVehicleTypeViews);

                foreach (BlackOut deletedBlackOut in DeletedBlackOuts)
                {
                    if (deletedBlackOut.BlackOutId > 0)
                    {
                        _context.Entry(deletedBlackOut).State = EntityState.Deleted;
                    }
                }

                foreach (TimeSlot deletedTimeSlot in DeletedTimeSlots)
                {
                    if (deletedTimeSlot.TimeSlotId > 0)
                    {
                        _context.Entry(deletedTimeSlot).State = EntityState.Deleted;
                    }
                }

                foreach (PremiumDate deletedPremiumDate in DeletedPremiumDates)
                {
                    if (deletedPremiumDate.PremiumDateId > 0)
                    {
                        _context.Entry(deletedPremiumDate).State = EntityState.Deleted;
                    }
                }

                foreach (VehicleType deletedVehicleType in DeletedVehicleTypes)
                {
                    if (deletedVehicleType.VehicleTypeId > 0)
                    {
                        _context.Entry(deletedVehicleType).State = EntityState.Deleted;
                    }
                }

                foreach (TimeSlot TimeSlot in transfer.TimeSlots)
                {
                    if (TimeSlot.TimeSlotId > 0)
                    {
                        _context.Entry(TimeSlot).State = EntityState.Modified;
                    }
                    else
                    {
                        _context.Entry(TimeSlot).State = EntityState.Added;
                    }
                }

                foreach (BlackOut BlackOut in transfer.BlackOuts)
                {
                    if (BlackOut.BlackOutId > 0)
                    {
                        _context.Entry(BlackOut).State = EntityState.Modified;
                    }
                    else
                    {
                        _context.Entry(BlackOut).State = EntityState.Added;
                    }
                }

                foreach (VehicleType VehicleType in transfer.VehicleTypes)
                {
                    if (VehicleType.VehicleTypeId > 0)
                    {
                        _context.Entry(VehicleType).State = EntityState.Modified;
                    }
                    else
                    {
                        _context.Entry(VehicleType).State = EntityState.Added;
                    }
                }

                foreach (PremiumDate PremiumDate in transfer.PremiumDates)
                {
                    if (PremiumDate.PremiumDateId > 0)
                    {
                        _context.Entry(PremiumDate).State = EntityState.Modified;
                    }
                    else
                    {
                        _context.Entry(PremiumDate).State = EntityState.Added;
                    }
                }

                _context.Entry(transfer).State = EntityState.Modified;
                _context.SaveChanges();

                returnObject.ChangedData = transfer;
                returnObject.isSuccess = true;
                returnObject.Message = returnObject.GetEditMessage();

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