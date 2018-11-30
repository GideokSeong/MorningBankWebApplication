using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MorningBank.Models.ViewModels
{
    [Serializable]
    public class TransactionHistoryModel : TransactionHistory
    {
        public string TransactionTypeName { get; set; }
    }
}