using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MorningBank.Models.ViewModels
{
    public class ApplyLoanModel
    {
        public int RoldId { get; set; }
        public decimal Amount { get; set; } 
        public string UserName { get; set; }
        public string Status { get; set; }
    }
}