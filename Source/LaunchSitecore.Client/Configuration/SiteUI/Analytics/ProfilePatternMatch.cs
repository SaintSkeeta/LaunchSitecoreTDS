using System;
using Sitecore.Analytics;
using Sitecore.Analytics.Tracking;
using Sitecore.Diagnostics;
using Sitecore.Data.Items;

namespace LaunchSitecore.Configuration.SiteUI.Analytics
{
 public class ProfilePatternMatch
 {
  private Item _profileItem;
  private Profile _profile;

  public ProfilePatternMatch(string profileId)
  {
   HasMatch = false;
   if (string.IsNullOrEmpty(profileId) && !Tracker.IsActive)
   {
    Log.Info("Cannot match pattern. Profile id or tracker not enabled", profileId);
    return;
   }
   if (!SetProfile(profileId))
   {
    Log.Info("Cannot match pattern.  Profile cannot be set", profileId);
    return;
   }
   if (!SetPattern())
   {
    Log.Info("Cannot match pattern.  Pattern item not available based on patternId", profileId);
    return;
   }
   HasMatch = true;
   Log.Info("Pattern matched", profileId);
  }

  private bool SetProfile(string profileId)
  {
   if (string.IsNullOrEmpty(profileId)) return false;
   var item = Sitecore.Context.Database.GetItem(profileId);
   if (item == null) return false;
   _profileItem = item;
   _profile = Tracker.Current.Interaction.Profiles[ProfileName];
   return _profile != null;
  }

  private bool SetPattern()
  {
   if (_profile == null) return false;
   PatternItem = Sitecore.Context.Database.GetItem(_profile.PatternId.ToId());
   return PatternItem != null;
  }

  public bool HasMatch { get; set; }

  public string ProfileName
  {
   get { return _profileItem != null ? _profileItem.Name : string.Empty; }
  }

  public Item PatternItem { get; set; }

  public string PatternName
  {
   get { return PatternItem != null ? PatternItem["Name"] : string.Empty; }
  }

  public string NoPatternMatchMessage
  {
   get
   {
    return "Unknown Pattern"; //TODO: Add dictionary text for multiple languages }
   }
  }
 }
}