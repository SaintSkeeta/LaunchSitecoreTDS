using LaunchSitecore.Configuration;
using Sitecore.Analytics;
using Sitecore.Analytics.Data.DataAccess.DataSets;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaunchSitecore.Models
{
  public class VisitInformation
  {
    public string PageCount
    {
      get { return Convert.ToString(Tracker.CurrentVisit.VisitPageCount); }
    }

    public string EngagementValue
    {
      get { return Convert.ToString(Tracker.CurrentVisit.Value); }
    }

    public string Campaign
    {
      get
      { 
        // the call to Tracker.CurrentVisit.CampaignId will either work or throw
        try
        {
          Item campaign = Sitecore.Context.Database.GetItem(new ID(Tracker.CurrentVisit.CampaignId));
          return campaign.Name;
        }
        catch { return SiteConfiguration.GetDictionaryText("Current Campaign Empty"); }
      }
    }

    public string City
    {
      get { return Tracker.CurrentVisit.HasGeoIpData ? Tracker.CurrentVisit.City : SiteConfiguration.GetDictionaryText("Pending Lookup"); }
    }

    public string PostalCode
    {
      get { return Tracker.CurrentVisit.HasGeoIpData ? Tracker.CurrentVisit.PostalCode : SiteConfiguration.GetDictionaryText("Pending Lookup"); }
    }

    public List<PatternMatch> PatternMatches { get { return LoadPatterns(); } }

    public List<GenericLink> PagesViewed { get { return LoadPages(); } }

    public List<PatternMatch> LoadPatterns()
    {
      List<PatternMatch> patternMatches = new List<PatternMatch>();

      if (SiteConfiguration.GetSiteSettingsItem() != null)
      {
        MultilistField profiles = SiteConfiguration.GetSiteSettingsItem().Fields["Visible Profiles"];
        foreach (Item vp in profiles.GetItems())
        {
          Item evaluatorTypeProfile = Sitecore.Context.Database.GetItem(vp.Paths.FullPath);
          if (evaluatorTypeProfile != null)
          {
            if (Sitecore.Analytics.Tracker.IsActive)
            {
              // show the pattern match if there is one.
              var personaProfile = Tracker.CurrentVisit.Profiles.Where(profile => profile.ProfileName == evaluatorTypeProfile.Name).FirstOrDefault();
              if (personaProfile != null)
              {
                // load the details about the matching pattern
                Item i = Sitecore.Context.Database.GetItem(new ID(personaProfile.PatternId));
                if (i != null)
                {
                  Sitecore.Data.Items.MediaItem image = new Sitecore.Data.Items.MediaItem(((ImageField)i.Fields["Image"]).MediaItem);
                  string src = Sitecore.StringUtil.EnsurePrefix('/', Sitecore.Resources.Media.MediaManager.GetMediaUrl(image));
                  patternMatches.Add(new PatternMatch(evaluatorTypeProfile["Name"], i.Name, src));
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
      List<GenericLink> pagesViewed = new List<GenericLink>();

      foreach (VisitorDataSet.PagesRow page in Tracker.CurrentVisit.GetPages())
      {
        GenericLink link = new GenericLink(CleanPageName(page), page.Url, false);
        pagesViewed.Add(link);
      }
      pagesViewed.Reverse();
      return pagesViewed;
    }

    private string CleanPageName(VisitorDataSet.PagesRow p)
    {
      string pageName = p.Url.Replace("/en", "/").Replace("//", "/").Remove(0, 1).Replace(".aspx", "");
      if (pageName == String.Empty || pageName == "en") pageName = "Home";
      if (pageName.IndexOf("/") != pageName.LastIndexOf("/"))
      {
        pageName = pageName.Substring(0, pageName.IndexOf("/") + 1) + "..." + pageName.Substring(pageName.LastIndexOf("/"));
      }
      return (pageName.Length < 27) ? String.Format("{0} ({1}s)", pageName, (p.Duration / 1000.0).ToString("f2")) :
          String.Format("{0}... ({1}s)", pageName.Substring(0, 26), (p.Duration / 1000.0).ToString("f2"));     
    }

    private string CleanGoalDescription(VisitorDataSet.PageEventsRow a)
    {
      return String.Format("{0} ({1})", a.PageEventDefinition.Name, a.PageEventDefinition.Points); 
    }

    protected void FakeIPForLocalhost()
    {
      VisitorDataSet.VisitsRow currentVisit = Tracker.Visitor.GetCurrentVisit();
      if (currentVisit != null)
      {
        // if we are local host. our IP is 127 which will not resolve so I am using a 'fake' ip address
        if (currentVisit.Ip[0] == 127)
        {
          currentVisit.Ip[0] = Convert.ToByte(SiteConfiguration.GetSiteSettingsItem()["IP1"]);
          currentVisit.Ip[1] = Convert.ToByte(SiteConfiguration.GetSiteSettingsItem()["IP2"]);
          currentVisit.Ip[2] = Convert.ToByte(SiteConfiguration.GetSiteSettingsItem()["IP3"]);
          currentVisit.Ip[3] = Convert.ToByte(SiteConfiguration.GetSiteSettingsItem()["IP4"]);

          // Sitecore may have already tried to resolve the 127 and failed, so this will initiate a retry
          currentVisit.HasGeoIpData = false;

          // Save our changes and let DMS request the GeoIP data again.  
          currentVisit.UpdateGeoIpData(new TimeSpan(0, 0, 0, 0, 100));
          currentVisit.AcceptChanges();
        }
      }
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