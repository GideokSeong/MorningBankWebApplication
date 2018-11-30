using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MorningBank.Models.ViewModels
{
    public class PhoneBillModel
    {
        public long CheckingAccountNumber { get; set; }
        public decimal CheckingBalance { get; set; }
        [Range(0, 100000, ErrorMessage = "invalid amount specified")]
        public decimal Amount { get; set; }
    }
}