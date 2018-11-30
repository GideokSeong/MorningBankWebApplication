using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorningBank.DataLayer
{
    interface IRepositoryAuthentication
    {
        bool CheckIfValidUser(string username, string password);
        string GetRolesForUser(string username);
        bool ChangePassword(string username, string oldPassword, string newPassword);
    }
}
