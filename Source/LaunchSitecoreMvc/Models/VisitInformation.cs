using LaunchSitecore.Configuration;
using Sitecore.Analytics;
using Sitecore.Analytics.Automation.Data;
using Sitecore.Analytics.Tracking;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LaunchSitecore.Models
{
    public class VisitInformation
    {
        public string PageCount
        {
            get { return Convert.ToString(Tracker.Current.Interaction.PageCount); }
        }

        public string EngagementValue
        {
            get { return Convert.ToString(Tracker.Current.Interaction.Value); }
        }

        public string Campaign
        {
            get
            {
                if (Tracker.Current.Interaction.CampaignId.HasValue)
                {
                    Item campaign = Sitecore.Context.Database.GetItem(Tracker.Current.Interaction.CampaignId.ToId());
                    if (campaign != null) return campaign.Name;
                }

                return SiteConfiguration.GetDictionaryText("Current Campaign Empty");
            }
        }

        public string City
        {
            get { return Tracker.Current.Interaction.HasGeoIpData ? Tracker.Current.Interaction.GeoData.City : SiteConfiguration.GetDictionaryText("Pending Lookup"); }
        }

        public string PostalCode
        {
            get { return Tracker.Current.Interaction.HasGeoIpData ? Tracker.Current.Interaction.GeoData.PostalCode : SiteConfiguration.GetDictionaryText("Pending Lookup"); }
        }

        public List<PatternMatch> PatternMatches { get { return LoadPatterns(); } }

        public List<GenericLink> PagesViewed { get { return LoadPages(); } }

        public List<string> GoalsList { get { return LoadGoals(); } }

        //public List<string> EngagementStates { get { return LoadEngagementStates(); } }

        public List<PatternMatch> LoadPatterns()
        {
            List<PatternMatch> patternMatches = new List<PatternMatch>();

            if (Tracker.IsActive)
            {
                if (SiteConfiguration.GetSiteConfigurationItem() != null)
                {
                    MultilistField profiles = SiteConfiguration.GetSiteConfigurationItem().Fields["Visible Profiles"];
                    foreach (Item visibleProfile in profiles.GetItems())
                    {
                        Item visibleProfileItem = Sitecore.Context.Database.GetItem(visibleProfile.ID);
                        if (visibleProfileItem != null)
                        {
                            // show the pattern match if there is one.
                            var userPattern = Tracker.Current.Interaction.Profiles[visibleProfileItem.Name];
                            if (userPattern != null)
                            {
                                // load the details about the matching pattern
                                if (userPattern.PatternId.HasValue)
                                {
                                    Item matchingPattern = Sitecore.Context.Database.GetItem(userPattern.PatternId.ToId());
                                    if (matchingPattern != null)
                                    {
                                        Sitecore.Data.Items.MediaItem image =
                                            new Sitecore.Data.Items.MediaItem(
                                                ((ImageField)matchingPattern.Fields["Image"]).MediaItem);
                                        string src = Sitecore.StringUtil.EnsurePrefix('/',
                                            Sitecore.Resources.Media.MediaManager.GetMediaUrl(image));
                                        patternMatches.Add(new PatternMatch(visibleProfileItem["Name"],
                                            matchingPattern.Name, src));
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return patternMatches;
        }

        public List<GenericLink> LoadPages()
        {
            //var a = Tracker.Current.Interaction.GetPages().Reverse();
            List<GenericLink> pagesViewed = new List<GenericLink>();
            foreach (IPageContext page in Tracker.Current.Interaction.GetPages())
            {
                GenericLink link = new GenericLink(CleanPageName(page), page.Url.Path, false);
                pagesViewed.Add(link);
            }
            pagesViewed.Reverse();
            return pagesViewed;
        }

        public List<string> LoadGoals()
        {
            List<string> goals = new List<string>();

            var conversions = (from page in Tracker.Current.Interaction.GetPages()
                               from pageEventData in page.PageEvents
                               where pageEventData.IsGoal
                               select pageEventData).ToList();

            if (conversions.Any())
            {
                conversions.Reverse();
                foreach (var goal in conversions)
                {
                    goals.Add(String.Format("{0} ({1})", goal.Name, goal.Value));
                }
            }
            else
            {
                goals.Add(SiteConfiguration.GetDictionaryText("No Goals"));
            }

            return goals;
        }

        //public List<string> LoadEngagementStates()
        //{
        //    List<string> states = new List<string>();

        //    try
        //    {
        //        var engagementstates = AutomationStateManager.Create(Tracker.Current.Contact).GetAutomationStates();

        //        if (engagementstates.Any())
        //        {
        //            foreach (
        //                AutomationStateContext context in
        //                    AutomationStateManager.Create(Tracker.Current.Contact).GetAutomationStates())
        //            {
        //                states.Add(String.Format("{0}: {1}", context.PlanItem.DisplayName, context.StateItem.DisplayName));
        //            }
        //        }
        //        else
        //        {
        //            states.Add(SiteConfiguration.GetDictionaryText("No Engagement States"));
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        states.Add(SiteConfiguration.GetDictionaryText("Unable to load Engagement States"));
        //    }
        //    return states;
        //}

        private string CleanPageName(IPageContext p)
        {
            string pageName = p.Url.Path.Replace("/en", "/").Replace("//", "/").Remove(0, 1).Replace(".aspx", "");
            if (pageName == String.Empty || pageName == "en") pageName = "Home";
            if (pageName.Contains("/"))
            {
                //pageName.Substring(0, pageName.IndexOf("/") + 1) +
                pageName =  "..." + pageName.Substring(pageName.LastIndexOf("/"));
            }
            return (pageName.Length < 27) ? String.Format("{0} ({1}s)", pageName, (p.Duration / 1000.0).ToString("f2")) :
                String.Format("{0}... ({1}s)", pageName.Substring(0, 26), (p.Duration / 1000.0).ToString("f2"));
        }
    }

    public class PatternMatch
    {
        public PatternMatch() { }
        public PatternMatch(string profile, string pattern, string image)
        {
            Profile = profile;
            PatternName = pattern;
            Image = image;
        }
        public string Profile { get; set; }
        public string PatternName { get; set; }
        public string Image { get; set; }
    }
}