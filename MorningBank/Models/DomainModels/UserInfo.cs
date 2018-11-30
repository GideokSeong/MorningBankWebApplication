using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MorningBank.Models.DomainModels
{
    [Serializable]
    public class UserInfo
    {
        public string Username { get; set; }
        public long CheckingAcccountNumber { get; set; }
        public long SavingAccountNumber { get; set; }
    }
}