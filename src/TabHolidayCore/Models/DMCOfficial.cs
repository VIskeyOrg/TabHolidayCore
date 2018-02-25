using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TabHolidayCore.Models
{
    public class DMCOfficial
    {
        [Key]
        public Int64 DMCOfficialId { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }

        public int DMCOfficialTypeId { get; set; }
        public DMCOfficialType DMCOfficialType { get; set; }
    }
}
