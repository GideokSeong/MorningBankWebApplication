using MorningBank.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MorningBank.Utils
{
    public class CookieFacade
    {
        static readonly string _UserInfo = "USERINFO";  // cookie name         
        static readonly string _UserData = "USERDATA";  // cookie sub field name

        public static UserInfo USERINFO
        {
            get
            {
                UserInfo res = null;
                HttpCookie ck = HttpContext.Current.Request.Cookies[_UserInfo];
                if (ck != null)
                {
                    res = (UserInfo)(ck[_UserData].LosDeserialize());
                }
                return res;
            }
            set
            {
                HttpCookie ck = new HttpCookie(_UserInfo);
                ck[_UserData] = value.LosSerialize();
                HttpContext.Current.Response.Cookies.Add(ck);
            }
        }
    }
}