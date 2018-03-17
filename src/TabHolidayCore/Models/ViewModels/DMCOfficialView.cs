using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TabHolidayCore.Models.ViewModels
{
    public class DMCOfficialView
    {
        public Int64 DMCOfficialId { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }

        public int DMCOfficialTypeId { get; set; }
        public DMCOfficialType DMCOfficialType { get; set; }

        //View specific columns
        public bool IsDelete { get; set; }
    }
}
