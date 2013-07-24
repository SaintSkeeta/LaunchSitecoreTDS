using System;
using LaunchSitecore.Configuration;
using Sitecore.Data.Items;
using Sitecore.Analytics;
using LaunchSitecore.Configuration.Analytics;

namespace LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Secure
{
    public partial class Register : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e) 
        {
            // load the labels from Sitecore
            if (!Page.IsPostBack)
            {
                litHeading.Text = SiteConfiguration.GetDictionaryText("Register Heading");
                lblName.Text = SiteConfiguration.GetDictionaryText("Name");
                lblEmail.Text = SiteConfiguration.GetDictionaryText("Email");
                lblPassword.Text = SiteConfiguration.GetDictionaryText("Password");
                lblConfirm.Text = SiteConfiguration.GetDictionaryText("Confirm Password");
                btnRegister.Text = SiteConfiguration.GetDictionaryText("Register Button");
                valName.Text = SiteConfiguration.GetDictionaryText("Required");
                valEmail.Text = SiteConfiguration.GetDictionaryText("Required");
                valPassword.Text = SiteConfiguration.GetDictionaryText("Required");
                valPasswordConfirm.Text = SiteConfiguration.GetDictionaryText("Required");
                valEmailFormat.Text = SiteConfiguration.GetDictionaryText("Email is Not Valid");
            }

            Item config = SiteConfiguration.GetSiteSettingsItem();
            if (config["Allow Online Registration"] != "1")
            {
                txtName.Enabled = false;
                txtEmail.Enabled = false;
                txtPassword.Enabled = false;
                txtPasswordConfirm.Enabled = false;
                btnRegister.Enabled = false;
                lblMessage.Text = SiteConfiguration.GetDictionaryText("Regisration is currently disabled for this site.");                
            }

        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if(txtPassword.Text != txtPasswordConfirm.Text) 
                { 
                    lblMessage.Text = SiteConfiguration.GetDictionaryText("Passwords do not match");  
                } 
                else 
                { 
                    string domainUser = Sitecore.Context.Domain.GetFullName(txtEmail.Text); 

                    try 
                    { 
                        if (Sitecore.Security.Accounts.User.Exists(domainUser)) 
                        { 
                            lblMessage.Text = SiteConfiguration.GetDictionaryText("Already registered");
                        }                         
                        else 
                        {                            
                            System.Web.Security.Membership.CreateUser(domainUser, txtPassword.Text, txtEmail.Text);                           
                                                         
                            if(Sitecore.Security.Authentication.AuthenticationManager.Login(domainUser, txtPassword.Text, false)) 
                            {
                                // Register Goal & set a few values in the visit tags.
                                Sitecore.Context.User.Profile.FullName = txtName.Text;
                                Sitecore.Context.User.Profile.Save();

                                Tracker.CurrentVisit.CurrentPage.Register("Register", "[Register] Username: \"" + domainUser + "\"");
                                Helper.SetVisitTagsOnLogin(domainUser);
                                Sitecore.Web.WebUtil.Redirect("/"); 
                            }                             
                        } 
                    }                     
                    catch(System.Web.Security.MembershipCreateUserException) 
                    { 
                        lblMessage.Text = SiteConfiguration.GetDictionaryText("Unable to register");
                    } 
                }            
            }
        } 
    } 
}