using System;
using Sitecore.Data.Items;
using System.Text;
using System.Collections.Specialized;
using System.Globalization;
using Sitecore.Globalization;
using System.Web.UI.HtmlControls;
using Sitecore.Analytics;
using Sitecore.Web.UI.WebControls;
using System.Linq;
using Sitecore.Analytics.Data.Items;
using Sitecore.Data;
using LaunchSitecore.Configuration.SiteUI.Base;
using System.Collections.Generic;

namespace LaunchSitecore.layouts.LaunchSitecore.Controls.Analytics
{
  public partial class Current_Pattern : SitecoreUserControlBase
  {
    public string ProfileKey { get; set; }

    private void Page_Load(object sender, EventArgs e)
    {
      if (Attributes["sc_datasource"] == null)
      {
        ShowError();
      }

      else
      {
        Item evaluatorTypeProfile = Sitecore.Context.Database.GetItem(Attributes["sc_datasource"]);
        if (evaluatorTypeProfile == null)
        {
          ShowError();
        }
        else
        {
          if (Sitecore.Analytics.Tracker.IsActive)
          {
            DMSTitle.Text = evaluatorTypeProfile["Name"];
            DMSTitle2.Text = evaluatorTypeProfile["Name"];
            DMSNoPatternMatchName.Text = GetDictionaryText("DMS Session Info No Pattern Match Name");

            // show the pattern match if there is one.
            var personaProfile = Tracker.CurrentVisit.Profiles.Where(profile => profile.ProfileName == evaluatorTypeProfile.Name).FirstOrDefault();
            if (personaProfile != null)
            {
              // load the details about the matching pattern
              Item i = Sitecore.Context.Database.GetItem(new ID(personaProfile.PatternId));
              if (i != null)
              {
                // make sure the right panels are showing
                PatternMatchPanel.Visible = true;
                PatternMatchPanelNoMatch.Visible = false;

                Name.Item = i;
                Image.Item = i;
              }
            }
          }
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