using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TabHolidayCore.Models.ViewModels
{
    public class BankDetailView
    {
        public Int64 BankDetailId { get; set; }
        public string Name { get; set; }
        public string BranchName { get; set; }
        public string AccountHolderName { get; set; }
        public string AccountNumber { get; set; }
        public string SwiftCode { get; set; }
        public string RoutingNumber { get; set; }
        public string IFSCCode { get; set; }
        public string MICRNumber { get; set; }
        public string IBANCode { get; set; }
        
        //View specific columns
        public bool IsDelete { get; set; }

        public int BankAccountTypeId { get; set; }
        public BankAccountType BankAccountType { get; set; }
    }
}
