using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Security.Accounts;
using System.Web.Security;
using Sitecore.SecurityModel;

namespace LaunchSitecore.Configuration.Security
{
    public class ResetUser
    {
        public static void ResetUserAccount(string username, string password)
        {
            //Disable security in case the user is running in a limited user capacity
            using (new SecurityDisabler())
            {
                Account a = Account.FromName(username, AccountType.User);
                if (a != null)
                {
                    MembershipUser user = Membership.GetUser(a.Name);

                    // Enable the Account
                    if (!user.IsApproved)
                    {
                        user.IsApproved = true;
                        Membership.UpdateUser(user);
                    }

                    // Reset the password
                    user.ChangePassword(user.ResetPassword(), password);
                }
            }            
        }
    }
}