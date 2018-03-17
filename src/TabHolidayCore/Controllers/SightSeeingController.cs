using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TabHolidayCore.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using TabHolidayCore.Models.ViewModels;


namespace TabHolidayCore.Controllers
{
    public class SightSeeingController : Controller
    {
        private readonly AppDbContext _context;
        private ReturnClass returnObject = new ReturnClass();
        private readonly IMapper _mapper;


        public SightSeeingController(AppDbContext context, IMapper mapper)
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
                SightSeeing[] SightSeeings = _context.SightSeeings.Include(s => s.StarRating).Include(a => a.SightSeeingCategory).Include(s=>s.Inclusions).Include(s=>s.BlackOuts).Include(s => s.TimeSlots).ToArray();
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

        [HttpPost]
        [Authorize]
        public string Edit([FromBody]SightSeeingView sightSeeingView)
        {
            try
            {
                List<InclusionView> deletedInclusionViews = new List<InclusionView>();
                List<BlackOutView> deletedBlackOutViews = new List<BlackOutView>();
                List<TimeSlotView> deletedTimeSlotViews = new List<TimeSlotView>();

                foreach(InclusionView deletedInclusionView in sightSeeingView.Inclusions)
                {
                    if(deletedInclusionView.IsDelete)
                    {
                        deletedInclusionViews.Add(deletedInclusionView);
                    }
                }

                foreach (BlackOutView deletedBlackOutView in sightSeeingView.BlackOuts)
                {
                    if (deletedBlackOutView.IsDelete)
                    {
                        deletedBlackOutViews.Add(deletedBlackOutView);
                    }
                }

                foreach (TimeSlotView deletedTimeSlotView in sightSeeingView.TimeSlots)
                {
                    if (deletedTimeSlotView.IsDelete)
                    {
                        deletedTimeSlotViews.Add(deletedTimeSlotView);
                    }
                }

                for(int i= sightSeeingView.Inclusions.Count;i>0;i--)
                {
                    if(sightSeeingView.Inclusions.ElementAt(i-1).IsDelete)
                    {
                        sightSeeingView.Inclusions.Remove(sightSeeingView.Inclusions.ElementAt(i - 1));
                    }
                }

                for (int i = sightSeeingView.TimeSlots.Count; i > 0; i--)
                {
                    if (sightSeeingView.TimeSlots.ElementAt(i - 1).IsDelete)
                    {
                        sightSeeingView.TimeSlots.Remove(sightSeeingView.TimeSlots.ElementAt(i - 1));
                    }
                }

                for (int i = sightSeeingView.TimeSlots.Count; i > 0; i--)
                {
                    if (sightSeeingView.TimeSlots.ElementAt(i - 1).IsDelete)
                    {
                        sightSeeingView.TimeSlots.Remove(sightSeeingView.TimeSlots.ElementAt(i - 1));
                    }
                }


                sightSeeingView.Inclusions.ToList().RemoveAll(b => b.IsDelete);
                sightSeeingView.BlackOuts.ToList().RemoveAll(b => b.IsDelete);
                sightSeeingView.TimeSlots.ToList().RemoveAll(b => b.IsDelete);

                SightSeeing sightSeeing = _mapper.Map<SightSeeing>(sightSeeingView);

                List<Inclusion> DeletedInclusions = new List<Inclusion>();
                List<BlackOut> DeletedBlackOuts = new List<BlackOut>();
                List<TimeSlot> DeletedTimeSlots = new List<TimeSlot>();

                DeletedInclusions = _mapper.Map<List<Inclusion>>(deletedInclusionViews);
                DeletedBlackOuts = _mapper.Map<List<BlackOut>>(deletedBlackOutViews);
                DeletedTimeSlots = _mapper.Map<List<TimeSlot>>(deletedTimeSlotViews);

                

                foreach (Inclusion deletedInclusion in DeletedInclusions)
                {
                    if (deletedInclusion.InclusionId > 0)
                    {
                        _context.Entry(deletedInclusion).State = EntityState.Deleted;
                    }
                }

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

                foreach (Inclusion Inclusion in sightSeeing.Inclusions)
                {
                    if (Inclusion.InclusionId > 0)
                    {
                        _context.Entry(Inclusion).State = EntityState.Modified;
                    }
                    else
                    {
                        _context.Entry(Inclusion).State = EntityState.Added;
                    }
                }

                foreach (TimeSlot TimeSlot in sightSeeing.TimeSlots)
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

                foreach (BlackOut BlackOut in sightSeeing.BlackOuts)
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


                _context.Entry(sightSeeing).State = EntityState.Modified;
                _context.SaveChanges();

                returnObject.ChangedData = sightSeeing;
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