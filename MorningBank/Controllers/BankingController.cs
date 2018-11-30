using MorningBank.BusinessLayer;
using MorningBank.Models.DomainModels;
using MorningBank.Models.ViewModels;
using MorningBank.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MorningBank;

namespace MorningBank.Controllers
{
    [Authorize]
    public class BankingController : Controller
    {

        // GET: Banking
        public ActionResult LoanApproval()
        {
            LoanApprovalModel lam = new LoanApprovalModel();
            UserInfo ui = CookieFacade.USERINFO;
            IBusinessBanking ibank = GenericFactory<Business, IBusinessBanking>.GetInstance();

            
            lam.UserName = ibank.GetAllLoanUsers("pending");
            for ( int i=0;i< lam.UserName.Count; i++)
                lam.Status = ibank.ShowLoanStatus(lam.UserName[i]);
            ViewBag.Message = "";
            return View(lam);
        }

        [HttpPost]
        public ActionResult LoanApproval(LoanApprovalModel lam)
        {
            IBusinessBanking ibank = GenericFactory<Business, IBusinessBanking>.GetInstance();
            UserInfo ui = CookieFacade.USERINFO;
            if (ui.Username != "mark")
            {
                ViewBag.Message = "Only manager is available to change the loan status..";
            }
            try
            {
                if (ModelState.IsValid && ui.Username=="mark") 
                {
                    
                    bool ret = ibank.LoanApproval(ui.CheckingAcccountNumber, ui.SavingAccountNumber, lam.Amount, lam.UserName);

                    if (ret == true)
                    {
                        ViewBag.Message = "Loan status changed successfully..";
                        ModelState.Clear();
                        // otherwise, textbox will display the old amount                         
                        lam.Status = "Approved";
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            //alm.Amount = ibank.GetAmountDue(ui.CheckingAcccountNumber);
            return View(lam);
        }

        public ActionResult LoanStatus()
        {
            LoanStatusModel lsm = new LoanStatusModel();
            UserInfo ui = CookieFacade.USERINFO;
            IBusinessBanking ibank = GenericFactory<Business, IBusinessBanking>.GetInstance();

            lsm.Username = ui.Username;
            string ret = ibank.ShowLoanStatus(ui.Username);
            lsm.Status = ret;

            ViewBag.Message = "";
            return View(lsm);
        }

        

        // GET: Banking
        public ActionResult ApplyLoan()
        {
            ApplyLoanModel alm = new ApplyLoanModel();
            UserInfo ui = CookieFacade.USERINFO;
            IBusinessBanking ibank = GenericFactory<Business, IBusinessBanking>.GetInstance();
            
            alm.UserName = ui.Username;
            alm.Amount = ibank.GetAmountDue(ui.CheckingAcccountNumber);
            //alm.Status = ibank.GetAmountDue(ui.CheckingAcccountNumber);
            ViewBag.Message = "";
            return View(alm);
        }

        [HttpPost]
        public ActionResult ApplyLoan(ApplyLoanModel alm)
        {
            int count = 0;
            IBusinessBanking ibank = GenericFactory<Business, IBusinessBanking>.GetInstance();
            UserInfo ui = CookieFacade.USERINFO;
            if (ui.Username == "mark")
            {
                ViewBag.Message = "Only customer is available to apply the loan ..";
            }
            try
            {
                if (ModelState.IsValid && ui.Username!="mark" && count==0)
                {
                    if (count!=0)
                    {
                        ViewBag.Message = "You already applied the loan ..";
                    }
                    bool ret = ibank.ApplyLoan(ui.CheckingAcccountNumber, ui.SavingAccountNumber, alm.Amount, ui.Username);
                    if (ret == true)
                    {
                        ViewBag.Message = "Applied a loan successfully..";
                        ModelState.Clear();
                        // otherwise, textbox will display the old amount                         
                        alm.Amount = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            //alm.Amount = ibank.GetAmountDue(ui.CheckingAcccountNumber);
            return View(alm);
        }

        // GET: Banking
        public ActionResult PhoneBillPayment()
        {
            PhoneBillModel pbm = new PhoneBillModel();
            UserInfo ui = CookieFacade.USERINFO;
            IBusinessBanking ibank = GenericFactory<Business, IBusinessBanking>.GetInstance();
            pbm.CheckingAccountNumber = ui.CheckingAcccountNumber;
            pbm.CheckingBalance = ibank.GetCheckingBalance(ui.CheckingAcccountNumber);
            pbm.Amount = ibank.GetAmountDue(ui.CheckingAcccountNumber);
            ViewBag.Message = "";
            return View(pbm);
        }

        [HttpPost]
        public ActionResult PhoneBillPayment(PhoneBillModel pbm)
        {
            IBusinessBanking ibank = GenericFactory<Business, IBusinessBanking>.GetInstance();
            UserInfo ui = CookieFacade.USERINFO;
            try
            {
                if (ModelState.IsValid)
                {
                    bool ret = ibank.TransferBillFromChecking(ui.CheckingAcccountNumber, ui.SavingAccountNumber, pbm.Amount);
                    if (ret == true)
                    {
                        ViewBag.Message = "Transfer successful..";
                        ModelState.Clear();
                        // otherwise, textbox will display the old amount                         
                        pbm.Amount = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            pbm.CheckingBalance = ibank.GetCheckingBalance(ui.CheckingAcccountNumber);
            pbm.Amount = ibank.GetAmountDue(ui.CheckingAcccountNumber);
            return View(pbm);
        }
        // GET: Banking
        public ActionResult TransferCheckingToSaving()
        {
            TransferCToSModel tcs = new TransferCToSModel();
            UserInfo ui = CookieFacade.USERINFO;
            IBusinessBanking ibank = GenericFactory<Business, IBusinessBanking>.GetInstance();
            tcs.CheckingBalance = ibank.GetCheckingBalance(ui.CheckingAcccountNumber);
            tcs.SavingBalance = ibank.GetSavingBalance(ui.SavingAccountNumber);
            tcs.Amount = 5;
            ViewBag.Message = "";
            return View(tcs);
        }

        [HttpPost]
        public ActionResult TransferCheckingToSaving(TransferCToSModel tcs)
        {
            IBusinessBanking ibank = GenericFactory<Business, IBusinessBanking>.GetInstance();
            UserInfo ui = CookieFacade.USERINFO;
            try
            {
                if (ModelState.IsValid)
                {
                    bool ret = ibank.TransferCheckingToSaving(ui.CheckingAcccountNumber, ui.SavingAccountNumber, tcs.Amount);
                    if (ret == true)
                    {
                        ViewBag.Message = "Transfer successful..";
                        ModelState.Clear();
                        // otherwise, textbox will display the old amount                         
                        tcs.Amount = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            } 
            tcs.CheckingBalance = ibank.GetCheckingBalance(ui.CheckingAcccountNumber);
            tcs.SavingBalance = ibank.GetSavingBalance(ui.SavingAccountNumber);
            return View(tcs);
        }

        // GET: Banking
        public ActionResult TransferSavingToChecking()
        {
            TransferSToCModel tsc = new TransferSToCModel();
            UserInfo ui = CookieFacade.USERINFO;
            IBusinessBanking ibank = GenericFactory<Business, IBusinessBanking>.GetInstance();
            tsc.SavingBalance = ibank.GetSavingBalance(ui.SavingAccountNumber);
            tsc.CheckingBalance = ibank.GetCheckingBalance(ui.CheckingAcccountNumber);
            tsc.Amount = 5;
            ViewBag.Message = "";
            return View(tsc);
        }

        [HttpPost]
        public ActionResult TransferSavingToChecking(TransferSToCModel tsc)
        {
            IBusinessBanking ibank = GenericFactory<Business, IBusinessBanking>.GetInstance();
            UserInfo ui = CookieFacade.USERINFO;
            try
            {
                if (ModelState.IsValid)
                {
                    bool ret = ibank.TransferSavingToChecking(ui.CheckingAcccountNumber, ui.SavingAccountNumber, tsc.Amount);
                    if (ret == true)
                    {
                        ViewBag.Message = "Transfer successful..";
                        ModelState.Clear();
                        // otherwise, textbox will display the old amount                         
                        tsc.Amount = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            tsc.SavingBalance = ibank.GetSavingBalance(ui.SavingAccountNumber);
            tsc.CheckingBalance = ibank.GetCheckingBalance(ui.CheckingAcccountNumber);
            return View(tsc);
        }

        public ActionResult TransferHistory()
        {
            IBusinessBanking ibank = GenericFactory<Business, IBusinessBanking>.GetInstance();
            UserInfo ui = CookieFacade.USERINFO;
            List<TransactionHistoryModel> THList = ibank.GetTransactionHistory(ui.CheckingAcccountNumber);
                        
            return View(THList);
        }
    }
}