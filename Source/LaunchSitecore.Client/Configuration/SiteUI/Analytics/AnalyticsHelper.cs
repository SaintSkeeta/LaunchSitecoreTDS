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
            Tracker.Current.Contact.Identifiers.AuthenticationLevel =
                Sitecore.Analytics.Model.AuthenticationLevel.PasswordValidated;
            Tracker.Current.Session.Identify(domainUser);

            string name = Sitecore.Context.User.Profile.FullName;
            if (name == String.Empty) name = Sitecore.Context.User.LocalName;
            Tracker.Current.Contact.Tags.Add("Full name", name);
            Tracker.Current.Contact.Tags.Add("Username", domainUser);
        }
    }
}