using System;
using LaunchSitecore.Configuration.SiteUI.Analytics;
using LaunchSitecore.Configuration.SiteUI.Base;

namespace LaunchSitecore.layouts.LaunchSitecore.Controls.Analytics
{
 public partial class Current_Pattern : SitecoreUserControlBase
 {
  private void Page_Load(object sender, EventArgs e)
  {
   var profileId = Attributes["sc_datasource"];
   if (string.IsNullOrEmpty(profileId))
   {
    ShowError();
   }
   else
   {
    var ppm = new ProfilePatternMatch(profileId);

    DMSTitle.Text = ppm.ProfileName;
    DMSTitle2.Text = ppm.ProfileName;
    if (ppm.HasMatch)
    {
     PatternMatchPanel.Visible = true;
     PatternMatchPanelNoMatch.Visible = false;
     Name.Text = ppm.PatternName;
     Image.Item = ppm.PatternItem;
    }
    else
    {
     DMSNoPatternMatchName.Text = ppm.NoPatternMatchMessage;
    }
   }
  }
  private void ShowError()
  {
   PatternMatchPanel.Visible = false;
   PatternMatchPanelNoMatch.Visible = false;
   WriteAlert("datasource is null");
  }
 }
}