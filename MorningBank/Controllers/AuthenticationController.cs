using MorningBank.BusinessLayer;
using MorningBank.Cache;
using MorningBank.Models.DomainModels;
using MorningBank.Models.ViewModels;
using MorningBank.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MorningBank.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Login()
        {
            LoginModel lm = new LoginModel();
            return View(lm);
        }

        [HttpPost]
        public ActionResult Login(LoginModel lm)
        {
            IBusinessAuthentication iba = GenericFactory<Business, IBusinessAuthentication>.GetInstance();
            IBusinessBanking ibank = GenericFactory<Business, IBusinessBanking>.GetInstance();
            if (ModelState.IsValid)
            {
                // check if valid user                 
                bool ret = iba.CheckIfValidUser(lm.Username, lm.Password);
                if (ret == true)
                {
                    string roles = iba.GetRolesForUser(lm.Username);
                    // send the pipedelimited roles as an authentication cookie back to the browser                     
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, lm.Username, DateTime.Now, DateTime.Now.AddMinutes(15), false, roles);
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    HttpCookie ck = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    Response.Cookies.Add(ck);
                    // ----obtaing checking account number and saving account number for user                     
                    long checkingAccountNum = ibank.GetCheckingAccountNumForUser(lm.Username);
                    long savingAccountNumber = ibank.GetSavingAccountNumForUser(lm.Username);
                    UserInfo ui = new UserInfo();
                    ui.CheckingAcccountNumber = checkingAccountNum;
                    ui.SavingAccountNumber = savingAccountNumber;
                    ui.Username = lm.Username;
                    //HttpCookie ckuser = new HttpCookie("UserInfo");                     
                    //ckuser["USERDATA"] = ui.LosSerialize();                     
                    //Response.Cookies.Add(ckuser);                     
                    CookieFacade.USERINFO = ui; 
                

                    CacheAbstraction cabs = new CacheAbstraction();
                    cabs.Remove("TRHISTORY" + ":" + checkingAccountNum);
                    //----------------------------------------------------                                          
                    string redirectURL = FormsAuthentication.GetRedirectUrl(lm.Username, false);
                    if (redirectURL == "/default.aspx")
                        redirectURL = "~/home/index";
                    //Response.Redirect(redirectURL);  
                    // causes antiforgery token exception                     
                    return Redirect(redirectURL);
                }
                ViewBag.Message = "Invalid login..";
            }
            return View(lm);
        }

        public ActionResult Logout()
        {
            HttpCookie ckuser = new HttpCookie("UserInfo");
            ckuser.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(ckuser);
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}