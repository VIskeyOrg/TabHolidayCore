using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TabHolidayCore.Models.ViewModels
{
    public class DMCView
    {
        public Int64 DMCId { get; set; }
        public string Name { get; set; }
        public string OfficeNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Address { get; set; }
        public string TaxNumber { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<BankDetailView> BankDetails { get; set; }
        public ICollection<DMCOfficialView> DMCOfficials { get; set; }
    }
}
