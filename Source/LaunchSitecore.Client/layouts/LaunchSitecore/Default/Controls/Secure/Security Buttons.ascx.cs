using System;
using LaunchSitecore.Configuration;

namespace LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Secure
{
    public partial class Security_Buttons : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            Login.Text = SiteConfiguration.GetDictionaryText("Login");
            Register.Text = SiteConfiguration.GetDictionaryText("Register");
            MyFavorites.Text = SiteConfiguration.GetDictionaryText("My Favorites");            
            btnLogout.Text = SiteConfiguration.GetDictionaryText("Logout");

            if (Sitecore.Context.IsLoggedIn && Sitecore.Context.Domain.Name.ToLower() == "extranet")
            {
                authenticatedUser.Visible = true;
                loginButtons.Visible = false;
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Sitecore.Security.Authentication.AuthenticationManager.Logout();
            authenticatedUser.Visible = false;
            loginButtons.Visible = true;

            // redirect back to the home 
            Sitecore.Web.WebUtil.Redirect("/"); 
        }
    }
}