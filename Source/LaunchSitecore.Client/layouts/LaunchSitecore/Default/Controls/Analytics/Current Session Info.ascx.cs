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
using LaunchSitecore.Configuration;
using System.Collections.Generic; 

namespace LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Analytics
{
    public partial class Current_Session_Info : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            Logo.Item = SiteConfiguration.GetPresentationSettingsItem();

            DMSTitle.Text = SiteConfiguration.GetDictionaryText("DMS Session Info Title");
            DMSInstructions.Text = SiteConfiguration.GetDictionaryText("DMS Session Info Instructions");
            DMSNoPatternMatchName.Text = SiteConfiguration.GetDictionaryText("DMS Session Info No Pattern Match Name");
            DMSNoPatternMatch.Text = SiteConfiguration.GetDictionaryText("DMS Session Info No Pattern Match");
            DMSNoProfileValues.Text = SiteConfiguration.GetDictionaryText("DMS Session Info No Profile Key Values"); 
            
            if (Sitecore.Analytics.Tracker.IsActive)
            {
                // show the values for the evaluate type keys
                Item evaluatorTypeProfile = SiteConfiguration.GetPeelBackProfilePathItem();
                if (evaluatorTypeProfile != null)
                {
                    List<KeyValuePair<string, float>> results = new List<KeyValuePair<string, float>>();

                    if (Tracker.CurrentVisit.Profiles != null)
                    {
                        var selected = from profile in Tracker.Visitor.DataSet.Profiles
                                       where profile.ProfileName.Equals(evaluatorTypeProfile.Name, StringComparison.OrdinalIgnoreCase)
                                       select profile;

                        var groupedproffiles = selected.GroupBy(x => x.ProfileName);
                        foreach (var profile in groupedproffiles)
                        {
                            var profileItem = new ProfileItem(Sitecore.Context.Database.GetItem("/sitecore/system/Marketing Center/Profiles/" + profile.Key));
                            foreach (var key in profileItem.Keys)
                            {                                
                                results.Add(new KeyValuePair<string, float>(key.KeyName, Tracker.CurrentVisit.Profiles.Where(x => x.ProfileName.Equals(profile.Key)).FirstOrDefault().Values[key.KeyName]));
                            }

                            litProfileKey.Text = profile.Key;
                            ProfileValues.DataSource = results;
                            ProfileValues.DataBind();

                            ProfileKeyNoValues.Visible = false;
                            ProfileKeyValues.Visible = true;
                        }                        
                    }                             
                }

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
                        Description.Item = i;
                        Image.Item = i;                      
                    }
                }
            }
            else
            {
                DMSNote.Visible = true;
                DMSEnabled.Visible = false;
            }
        }        
    }
}