using System;
using System.Web.UI.WebControls;
using LaunchSitecore.Configuration.SiteUI.Base;
using Sitecore.Analytics;
using LaunchSitecore.Configuration.SiteUI.Analytics;


namespace LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Secure
{
    public partial class Login : SitecoreUserControlBase
    {
        protected void Page_Load(object sender, EventArgs e) 
        {
            // disable the login for CM users.
            if (!Sitecore.Context.PageMode.IsNormal || Sitecore.Context.PageMode.IsDebugging)
            {
                txtUsername.Enabled = false;
                txtPassword.Enabled = false;
                chkPersist.Enabled = false;
            }

            if (!Page.IsPostBack)
            {
                // load all of our labels from Sitecore
                litHeading.Text = GetDictionaryText("Login Heading");
                lblUsername.Text = GetDictionaryText("Email");
                lblPassword.Text = GetDictionaryText("Password");
                chkPersist.Text = GetDictionaryText("Persist Login");
                btnLogin.Text = GetDictionaryText("Login Button");
                valName.Text = GetDictionaryText("Required");
                valPass.Text = GetDictionaryText("Required");
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
                        AnalyticsHelper.SetVisitTagsOnLogin(domainUser);
                      if (!string.IsNullOrEmpty(Request.QueryString["item"]))
                      {
                        //TODO: FIx this with a decode
                        Response.Redirect(Request.QueryString["item"].Replace("%2f",@"/"));
                      }
                      Sitecore.Web.WebUtil.Redirect("/");
                    }
                    else
                    {
                        lblMessage.Text = GetDictionaryText("Invalid username or password");
                    }
                }
                catch (ApplicationException) 
                {
                    lblMessage.Text = GetDictionaryText("Unable to login"); 
                }
            }
        }
    }
}