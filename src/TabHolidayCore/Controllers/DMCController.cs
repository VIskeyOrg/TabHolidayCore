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
    public class DMCController : Controller
    {
        private readonly AppDbContext _context;
        private ReturnClass returnObject = new ReturnClass();
        private readonly IMapper _mapper;

        public DMCController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
                returnObject.ChangedData = DMCQuery.Include(d=>d.Country).Include(d=>d.BankDetails).Include(d=>d.DMCOfficials).ToArray();
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
        public string Edit([FromBody]DMCView dmcView)
        {

            try
            {
                List<BankDetailView> deletedBankDetailViews = new List<BankDetailView>();
                List<DMCOfficialView> deletedDMCOfficialViews = new List<DMCOfficialView>();

                foreach (BankDetailView deletedBankDetailView in dmcView.BankDetails)
                {
                    if (deletedBankDetailView.IsDelete)
                    {
                        deletedBankDetailViews.Add(deletedBankDetailView);
                    }
                }

                foreach (DMCOfficialView deletedDMCOfficialView in dmcView.DMCOfficials)
                {
                    if (deletedDMCOfficialView.IsDelete)
                    {
                        deletedDMCOfficialViews.Add(deletedDMCOfficialView);
                    }
                }

                dmcView.BankDetails.ToList().RemoveAll(b => b.IsDelete);
                dmcView.DMCOfficials.ToList().RemoveAll(d => d.IsDelete);

                DMC dmc = _mapper.Map<DMC>(dmcView);

                List<BankDetail> DeletedBankDetails = new List<BankDetail>();
                List<DMCOfficial> DeletedDMCOfficials = new List<DMCOfficial>();

                DeletedBankDetails = _mapper.Map<List<BankDetail>>(deletedBankDetailViews);
                DeletedDMCOfficials = _mapper.Map<List<DMCOfficial>>(deletedDMCOfficialViews);

                foreach (BankDetail deletedBankDetail in DeletedBankDetails)
                {
                    if (deletedBankDetail.BankDetailId > 0)
                    {
                        _context.Entry(deletedBankDetail).State = EntityState.Deleted;
                    }
                }

                foreach (DMCOfficial deletedDMCOfficial in DeletedDMCOfficials)
                {
                    if (deletedDMCOfficial.DMCOfficialId > 0)
                    {
                        _context.Entry(deletedDMCOfficial).State = EntityState.Deleted;
                    }
                }

                foreach(BankDetail bankDetail in dmc.BankDetails)
                {
                    if(bankDetail.BankDetailId > 0)
                    {
                        _context.Entry(bankDetail).State = EntityState.Modified;
                    }
                    else
                    {
                        _context.Entry(bankDetail).State = EntityState.Added;
                    }
                }

                foreach (DMCOfficial dmcOfficial in dmc.DMCOfficials)
                {
                    if (dmcOfficial.DMCOfficialId > 0)
                    {
                        _context.Entry(dmcOfficial).State = EntityState.Modified;
                    }
                    else
                    {
                        _context.Entry(dmcOfficial).State = EntityState.Added;
                    }
                }

                _context.Entry(dmc).State = EntityState.Modified;
                _context.SaveChanges();

                returnObject.ChangedData = dmc;
                returnObject.isSuccess = true;
                returnObject.Message = returnObject.GetEditMessage();
                return returnObject.GetResponse();
            }
            catch (Exception ex)
            {

                returnObject.isSuccess = false;
                returnObject.Message = returnObject.GetErrorMessage(ex);
                return returnObject.GetResponse();
            }
           
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}