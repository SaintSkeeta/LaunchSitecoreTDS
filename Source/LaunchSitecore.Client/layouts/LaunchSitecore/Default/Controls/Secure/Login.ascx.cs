using System;
using System.Web.UI.WebControls;
using LaunchSitecore.Configuration;
using Sitecore.Analytics;
using LaunchSitecore.Configuration.Analytics;

namespace LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Secure
{
    public partial class Login : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e) 
        {
            // disable the login for CM users.
            if (!Sitecore.Context.PageMode.IsNormal || Sitecore.Context.PageMode.IsDebugging)
            {
                txtUsername.Enabled = false;
                txtPassword.Enabled = false;
                chkPersist.Enabled = false;
                btnLogin.Enabled = false;
            }

            if (!Page.IsPostBack)
            {
                // load all of our labels from Sitecore
                litHeading.Text = SiteConfiguration.GetDictionaryText("Login Heading");
                lblUsername.Text = SiteConfiguration.GetDictionaryText("Email");
                lblPassword.Text = SiteConfiguration.GetDictionaryText("Password");
                chkPersist.Text = SiteConfiguration.GetDictionaryText("Persist Login");
                btnLogin.Text = SiteConfiguration.GetDictionaryText("Login Button");
                valName.Text = SiteConfiguration.GetDictionaryText("Required");
                valPass.Text = SiteConfiguration.GetDictionaryText("Required");
            }
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try 
                { 
                    Sitecore.Security.Domains.Domain domain = Sitecore.Context.Domain; 
                    string domainUser = domain.Name + @"\" + txtUsername.Text; 
                    if (Sitecore.Security.Authentication.AuthenticationManager.Login(domainUser, txtPassword.Text, chkPersist.Checked)) 
                    { 
                        // Register Goal & set a few values in the visit tags.
                        Tracker.CurrentVisit.CurrentPage.Register("Login", "[Login] Username: \"" + domainUser + "\"");
                        Helper.SetVisitTagsOnLogin(domainUser);                        
                        Sitecore.Web.WebUtil.Redirect("/"); 
                    } 
                    else 
                    {                        
                        lblMessage.Text = SiteConfiguration.GetDictionaryText("Invalid username or password");
                    } 
                } 
                catch (ApplicationException) 
                {
                    lblMessage.Text = SiteConfiguration.GetDictionaryText("Unable to login"); 
                }
            }
        }
    }
}