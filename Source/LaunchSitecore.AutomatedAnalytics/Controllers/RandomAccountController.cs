using LaunchSitecore.Configuration.SiteUI.Analytics;
using Sitecore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaunchSitecore.AutomatedAnalytics.Controllers
{
    public class RandomAccountController : Controller
    {
        private const string USER_PASSWORD = "Password1";

        // GET: Account
        public ActionResult Login()
        {
            Sitecore.Security.Domains.Domain domain = Sitecore.Context.Domain;
            var randomLogin = this.GetRandomLoginDetails();
            
            string domainUser = domain.Name + @"\" + randomLogin.EmailAddress;
            bool isNewUser = !Sitecore.Security.Accounts.User.Exists(domainUser);
            if (isNewUser)
            {
                System.Web.Security.Membership.CreateUser(domainUser, USER_PASSWORD, randomLogin.EmailAddress);
            }

            bool loginSuccessful = Sitecore.Security.Authentication.AuthenticationManager.Login(domainUser, USER_PASSWORD, false);
            if (!loginSuccessful)
            {
                Log.Error("Login/Register failed.", this);
                return null;
            }
            
            if (isNewUser)
            {
                // Register Goal & set a few values in the visit tags.
                Sitecore.Context.User.Profile.FullName = randomLogin.FirstName + " " + randomLogin.LastName;
                Sitecore.Context.User.Profile.ProfileItemId = "{93B42F5F-17A9-441B-AB6D-444F714EF384}"; //LS User
                Sitecore.Context.User.Profile.Save();

                AnalyticsHelper.RegisterGoalOnCurrentPage("Register", "[Register] Username: \"" + domainUser + "\"");
                AnalyticsHelper.SetVisitTagsOnLogin(domainUser, true);
            }
            else
            {
                // Register Goal & set a few values in the visit tags.
                AnalyticsHelper.RegisterGoalOnCurrentPage("Login", "[Login] Username: \"" + domainUser + "\"");
                AnalyticsHelper.SetVisitTagsOnLogin(domainUser, false);
            }

            return Redirect("/");
        }

        public ActionResult LogOff()
        {
            Sitecore.Security.Authentication.AuthenticationManager.Logout();

            Session.Abandon();
            return Redirect("/");
        }

        string[] FirstNames =
        {
            "John",
            "Steve",
            "Jason",
            "Michael",
            "Sean",
            "Nick",
            "Tom",
            "Derek",
            "Charlie",
            "Ben",
            "Robert",
            "Mary",
            "Jane",
            "Catherine",
            "Sarah",
            "Brooke",
            "Elena",
            "Martina",
            "Simone"
        };

        string[] LastNames =
        {
            "Smith",
            "Jones",
            "Brady",
            "Johnson",
            "Thomas",
            "Jackson",
            "Davis",
            "Carey",
            "McDonald",
            "Robinson"
        };

        string[] EmailDomains =
        {
            "hotmail.com",
            "gmail.com",
            "yahoo.com",
            "live.com"
        };

        private LoginModel GetRandomLoginDetails()
        {
            var randomGenerator = new Random();
            int randomFirstNameInt = randomGenerator.Next(1, FirstNames.Length);
            int randomLastNameInt = randomGenerator.Next(1, LastNames.Length);
            int randomEmailDomainInt = randomGenerator.Next(1, EmailDomains.Length);

            var loginDetails = new LoginModel() {
                FirstName = FirstNames.ElementAt(randomFirstNameInt - 1),
                LastName = LastNames.ElementAt(randomLastNameInt - 1),
            };

            string emailAddress = loginDetails.FirstName.ToLower() +
                                  "." +
                                  loginDetails.LastName.ToLower() +
                                  "@" +
                                  EmailDomains.ElementAt(randomEmailDomainInt - 1);
            loginDetails.EmailAddress = emailAddress;

            return loginDetails;

        }

        private class LoginModel
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string EmailAddress { get; set; }
        }
    }
}