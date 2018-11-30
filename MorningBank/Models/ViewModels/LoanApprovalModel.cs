using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MorningBank.Models.ViewModels
{
    public class LoanApprovalModel
    {
        public List<string> UserName { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
    }
}