using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TabHolidayCore.Models
{
    public class DMC
    {
        [Key]
        public Int64 DMCId { get; set; }
        public string Name { get; set; }
        public string OfficeNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Address { get; set; }
        public string TaxNumber { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<BankDetail> BankDetails { get; set; }
        public ICollection<DMCOfficial> DMCOfficials { get; set; }
    }
}
