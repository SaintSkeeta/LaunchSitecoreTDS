using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Analytics;

namespace LaunchSitecore.Configuration.SiteUI.Analytics
{
    public class AnalyticsHelper
    {
        public static void SetVisitTagsOnLogin(string domainUser)
        {
            Tracker.Visitor.AuthenticationLevel = Sitecore.Analytics.Data.DataAccess.AuthenticationLevel.PasswordValidated;
            Tracker.Visitor.ExternalUser = domainUser;

            string name = Sitecore.Context.User.Profile.FullName;
            if (name == String.Empty) name = Sitecore.Context.User.LocalName;
            Tracker.Visitor.Tags.Add("Full name", name);
            Tracker.Visitor.Tags.Add("Username", domainUser);                  
        }
    }
}