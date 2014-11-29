using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Analytics;
using Sitecore.Analytics.Model;
using Sitecore.Analytics.Model.Entities;

namespace LaunchSitecore.Configuration.SiteUI.Analytics
{
    public class AnalyticsHelper
    {
        public static void SetVisitTagsOnLogin(string domainUser, bool IsNewUser)
        {
         string name = Sitecore.Context.User.Profile.FullName;
         if (name == String.Empty) name = Sitecore.Context.User.LocalName;
         Tracker.Current.Contact.Tags.Add("Username", domainUser);
         Tracker.Current.Contact.Tags.Add("Full name", name);

         Tracker.Current.Contact.Identifiers.AuthenticationLevel = AuthenticationLevel.PasswordValidated;
         Tracker.Current.Session.Identify(domainUser);

         if (IsNewUser)
         {
          IContactPersonalInfo personalFacet = Tracker.Current.Contact.GetFacet<IContactPersonalInfo>("Personal");
          personalFacet.FirstName = GetFirstName(name);
          personalFacet.Surname = GetSurName(name);

          IContactEmailAddresses addressesFacet = Tracker.Current.Contact.GetFacet<IContactEmailAddresses>("Emails");
          IEmailAddress address;
          if (!addressesFacet.Entries.Contains("work_email"))
          {
           address = addressesFacet.Entries.Create("work_email");
           address.SmtpAddress = GetEmailAddressFromUser(domainUser);
           addressesFacet.Preferred = "work_email";
          }
         }   
        }

        public static void RegisterGoalOnCurrentPage(string name, string text)
        {
         Tracker.Current.CurrentPage.Register(name, text);
        }

        private static string GetFirstName(string fullname)
        {
         if (fullname.Contains(' '))
          return fullname.Substring(0, fullname.IndexOf(" "));

         return fullname;
        }

        private static string GetSurName(string fullname)
        {
         if (fullname.Contains(' '))
          return fullname.Substring(fullname.IndexOf(" ") + 1);

         return String.Empty;
        }

        private static string GetEmailAddressFromUser(string username)
        {
         if (username.Contains('\\'))
          return username.Substring(username.IndexOf("\\") + 1);

         return String.Empty;
        }
    }
}