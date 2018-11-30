using MorningBank.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorningBank.DataLayer
{
    interface IRepositoryBanking
    {
        decimal GetAmountDue(long checkingAccountNum);
        decimal GetCheckingBalance(long checkingAccountNum);
        decimal GetSavingBalance(long savingAccountNum);
        long GetCheckingAccountNumForUser(string username);
        long GetSavingAccountNumForUser(string username);
        bool TransferBillFromChecking(long checkingAccountNum, long savingAccountNum, decimal amount, decimal transactionFee);
        bool TransferCheckingToSaving(long checkingAccountNum, long savingAccountNum, decimal amount, decimal transactionFee);
        bool TransferSavingToChecking(long checkingAccountNum, long savingAccountNum, decimal amount, decimal transactionFee);
        bool ApplyLoan(long CheckingAcccountNumber, long SavingAccountNumber, decimal amount, string username, decimal transactionFee);
        string ShowLoanStatus(string username);
        bool LoanApproval(long CheckingAcccountNumber, long SavingAccountNumber, decimal Amount, List<string> Username, decimal transactionFee);
        List<string> GetAllLoanUsers(string status);
        List<MorningBank.Models.ViewModels.TransactionHistoryModel> GetTransactionHistory(long checkingAccountNum);
    }
}
