using MorningBank.DataLayer;
using MorningBank.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MorningBank.BusinessLayer
{
    class Business : IBusinessAuthentication, IBusinessBanking
    {
        IRepositoryAuthentication _iauth = null;
        IRepositoryBanking _ibank = null;
        public Business(IRepositoryAuthentication iauth, IRepositoryBanking ibank)
        {
            _iauth = iauth;
            _ibank = ibank;
        }

        public Business() :
            this(GenericFactory<Repository, IRepositoryAuthentication>.GetInstance(), GenericFactory<Repository, IRepositoryBanking>.GetInstance())
        { }

        public bool CheckIfValidUser(string username, string password)
        {
            return _iauth.CheckIfValidUser(username, password);
        }

        public string GetRolesForUser(string username)
        {
            return _iauth.GetRolesForUser(username);
        }

        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public decimal GetAmountDue(long checkingAccountNum)
        {
            return _ibank.GetAmountDue(checkingAccountNum);
        }
        public decimal GetCheckingBalance(long checkingAccountNum)
        {
            return _ibank.GetCheckingBalance(checkingAccountNum);
        }

        public decimal GetSavingBalance(long savingAccountNum)
        {
            return _ibank.GetSavingBalance(savingAccountNum);
        }

        public long GetCheckingAccountNumForUser(string username)
        {
            return _ibank.GetCheckingAccountNumForUser(username);
        }

        public long GetSavingAccountNumForUser(string username)
        {
            return _ibank.GetSavingAccountNumForUser(username);
        }
        public bool ApplyLoan(long CheckingAcccountNumber, long SavingAccountNumber, decimal amount, string username)
        {
            return _ibank.ApplyLoan(CheckingAcccountNumber, SavingAccountNumber, amount, username, 0);
        }
        public bool LoanApproval(long CheckingAcccountNumber, long SavingAccountNumber, decimal Amount, List<string> Username)
        {
            return _ibank.LoanApproval(CheckingAcccountNumber, SavingAccountNumber, Amount, Username, 0);
        }
        public List<string> GetAllLoanUsers(string status)
        {
            return _ibank.GetAllLoanUsers("pending");
        }
        public bool TransferBillFromChecking(long checkingAccountNum, long savingAccountNum, decimal amount)
        {
            return _ibank.TransferBillFromChecking(checkingAccountNum, savingAccountNum, amount, 0);
        }
        public string ShowLoanStatus(string username)
        {
            return _ibank.ShowLoanStatus(username);
        }
        public bool TransferCheckingToSaving(long checkingAccountNum, long savingAccountNum, decimal amount)
        {
            return _ibank.TransferCheckingToSaving(checkingAccountNum, savingAccountNum, amount, 0);
        }

        public bool TransferSavingToChecking(long checkingAccountNum, long savingAccountNum, decimal amount)
        {
            return _ibank.TransferSavingToChecking(checkingAccountNum, savingAccountNum, amount, 0);
        }

        List<MorningBank.Models.ViewModels.TransactionHistoryModel> IBusinessBanking.GetTransactionHistory(long checkingAccountNum)
        {
            return _ibank.GetTransactionHistory(checkingAccountNum);
        }
    }
}