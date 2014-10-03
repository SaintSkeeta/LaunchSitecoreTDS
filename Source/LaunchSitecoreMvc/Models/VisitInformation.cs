using LaunchSitecore.Configuration;
using Sitecore.Analytics;
using Sitecore.Analytics.Tracking;
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
    // the call to Tracker.CurrentVisit.CampaignId will either work or throw       
    try
    {
     if (Tracker.Current.Interaction.CampaignId.HasValue)
     {
      Item campaign = Sitecore.Context.Database.GetItem(new ID(Tracker.Current.Interaction.CampaignId.Value));
      return campaign.Name;
     }
    }
    catch { }

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

  public List<PatternMatch> LoadPatterns()
  {
   List<PatternMatch> patternMatches = new List<PatternMatch>();
   
   if (Tracker.IsActive)
   {
    if (SiteConfiguration.GetSiteSettingsItem() != null)
    {
     MultilistField profiles = SiteConfiguration.GetSiteSettingsItem().Fields["Visible Profiles"];
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
        Item matchingPattern = Sitecore.Context.Database.GetItem(userPattern.PatternId.ToId());
        if (matchingPattern != null)
        {
         Sitecore.Data.Items.MediaItem image = new Sitecore.Data.Items.MediaItem(((ImageField) matchingPattern.Fields["Image"]).MediaItem);
         string src = Sitecore.StringUtil.EnsurePrefix('/', Sitecore.Resources.Media.MediaManager.GetMediaUrl(image));
         patternMatches.Add(new PatternMatch(visibleProfileItem["Name"], matchingPattern.Name, src));
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

   foreach (IPageContext page in Tracker.Current.Interaction.GetPages())
   {
    GenericLink link = new GenericLink(CleanPageName(page), page.Url.Path, false);
    pagesViewed.Add(link);
   }
   pagesViewed.Reverse();
   return pagesViewed;
  }

  private string CleanPageName(IPageContext p)
  {
   string pageName = p.Url.Path.Replace("/en", "/").Replace("//", "/").Remove(0, 1).Replace(".aspx", "");
   if (pageName == String.Empty || pageName == "en") pageName = "Home";
   if (pageName.IndexOf("/") != pageName.LastIndexOf("/"))
   {
    pageName = pageName.Substring(0, pageName.IndexOf("/") + 1) + "..." + pageName.Substring(pageName.LastIndexOf("/"));
   }
   return (pageName.Length < 27) ? String.Format("{0} ({1}s)", pageName, (p.Duration / 1000.0).ToString("f2")) :
       String.Format("{0}... ({1}s)", pageName.Substring(0, 26), (p.Duration / 1000.0).ToString("f2"));
  }

  protected void FakeIPForLocalhost()
  {
   var ci = Tracker.Current.Interaction;
   if (ci != null)
   {
    // if we are local host. our IP is 127 which will not resolve so I am using a 'fake' ip address
    if (ci.Ip[0] == 127)
    {
     ci.Ip[0] = Convert.ToByte(SiteConfiguration.GetSiteSettingsItem()["IP1"]);
     ci.Ip[1] = Convert.ToByte(SiteConfiguration.GetSiteSettingsItem()["IP2"]);
     ci.Ip[2] = Convert.ToByte(SiteConfiguration.GetSiteSettingsItem()["IP3"]);
     ci.Ip[3] = Convert.ToByte(SiteConfiguration.GetSiteSettingsItem()["IP4"]);

     // Sitecore may have already tried to resolve the 127 and failed, so this will initiate a retry
     //ci.SetGeoData(null);

     // Save our changes and let DMS request the GeoIP data again.  
     ci.UpdateGeoIpData(new TimeSpan(0, 0, 0, 0, 100));
     ci.AcceptModifications();
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