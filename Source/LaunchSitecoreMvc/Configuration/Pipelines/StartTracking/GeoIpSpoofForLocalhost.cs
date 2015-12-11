using Sitecore.Analytics;
using Sitecore.Analytics.Pipelines.StartTracking;
using Sitecore.Diagnostics;
using System;

namespace LaunchSitecore.Configuration.Pipelines.StartTracking
{
 public class GeoIpSpoofForLocalhost
 {
  public void Process(StartTrackingArgs args)
  {
   Assert.IsNotNull((object)Tracker.Current, "Tracker.Current is not initialized");
   Assert.IsNotNull((object)Tracker.Current.Session, "Tracker.Current.Session is not initialized");
   if (Tracker.Current.Session.Interaction == null)
    return;

   // Since the source IP address to localhost is 127.0.0.1, we will not get back any geo ip information.  
   // We are switching the address of our visit to something that will resolve and give us something back.
   if (Tracker.Current.Session.Interaction.Ip[0] == 127 && !Tracker.Current.Session.Interaction.HasGeoIpData)
   {
    //todo: add some error handling
    string[] ip = Sitecore.Configuration.Settings.GetSetting("LaunchSitecore.GeoIpSpoofForLocalhost.DefaultIPAddress").Split('.');
    if (ip.Length == 4)
    {
     Tracker.Current.Session.Interaction.Ip[0] = Convert.ToByte(ip[0]);
     Tracker.Current.Session.Interaction.Ip[1] = Convert.ToByte(ip[1]);
     Tracker.Current.Session.Interaction.Ip[2] = Convert.ToByte(ip[2]);
     Tracker.Current.Session.Interaction.Ip[3] = Convert.ToByte(ip[3]);
    }
   }
  }
 }
}