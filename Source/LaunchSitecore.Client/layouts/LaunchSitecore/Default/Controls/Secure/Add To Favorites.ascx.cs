using System;
using LaunchSitecore.Configuration;
using Sitecore.Analytics;

namespace LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Secure
{
    public partial class Add_To_Favorites : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            // only show if logged in
            if (Sitecore.Context.User.IsAuthenticated)
            {
                // keep it hidden except on articles.
                if (Sitecore.Context.Item.Template.Key == "article")
                {
                    btnSave.Visible = true;
                }

                SetButtonText();                
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Sitecore.Security.Accounts.User user = Sitecore.Context.User;
            Sitecore.Security.UserProfile profile = user.Profile;
            string favorites = profile.GetCustomProperty("Favorites");

            // determine if we are adding or removing.  
            // We don't know the text of the button because it is managed in the CMS, so we will use the class of the button which we control.            
            if (btnSave.CssClass == "remove")
            {
                favorites = favorites.Replace(Sitecore.Context.Item.ID.ToString(), String.Empty);
                favorites = favorites.Replace("||", "|"); // when removeing we may leave a double pipe
                if (favorites == "|") { favorites = String.Empty; }
            }
            else // it must be an add
            { 
                if (favorites == String.Empty) { favorites = Sitecore.Context.Item.ID.ToString(); }
                else { favorites = favorites + "|" + Sitecore.Context.Item.ID.ToString(); }                
            }

            profile.SetCustomProperty("Favorites", favorites); 
            profile.Save();

            SetButtonText();

            // Capture the goal
            Tracker.CurrentVisit.CurrentPage.Register("Add a Favorite", "[Add a Favorite] Article: \"" + Sitecore.Context.Item.Name + "\"");
        }

        private void SetButtonText()
        {
            Sitecore.Security.Accounts.User user = Sitecore.Context.User;
            Sitecore.Security.UserProfile profile = user.Profile;
            string favorites = profile.GetCustomProperty("Favorites");

            if (favorites.Contains(Sitecore.Context.Item.ID.ToString()))
            {
                btnSave.Text = SiteConfiguration.GetDictionaryText("Remove from Favorites");
                btnSave.CssClass = "remove";
            }
            else
            {
                btnSave.Text = SiteConfiguration.GetDictionaryText("Add to Favorites"); 
                btnSave.CssClass = "add";
            }
        }
    }
}