using System;
using LaunchSitecore.Configuration;
using Sitecore.Data.Items;
using Sitecore.Analytics;
using LaunchSitecore.Configuration.SiteUI.Analytics;
using Sitecore.Diagnostics;
using LaunchSitecore.Configuration.SiteUI.Base;

namespace LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Secure
{
    public partial class Register : SitecoreUserControlBase
    {
        protected void Page_Load(object sender, EventArgs e) 
        {
            // load the labels from Sitecore
            if (!Page.IsPostBack)
            {
                litHeading.Text = GetDictionaryText("Register Heading");
                lblName.Text = GetDictionaryText("Name");
                lblEmail.Text = GetDictionaryText("Email");
                lblPassword.Text = GetDictionaryText("Password");
                lblConfirm.Text = GetDictionaryText("Confirm Password");
                btnRegister.Text = GetDictionaryText("Register Button");
                valName.Text = GetDictionaryText("Required");
                valEmail.Text = GetDictionaryText("Required");
                valPassword.Text = GetDictionaryText("Required");
                valPasswordConfirm.Text = GetDictionaryText("Required");
                valEmailFormat.Text = GetDictionaryText("Email is Not Valid");
            }

            Item config = SiteConfiguration.GetSiteSettingsItem();
            if (config["Allow Online Registration"] != "1")
            {
                txtName.Enabled = false;
                txtEmail.Enabled = false;
                txtPassword.Enabled = false;
                txtPasswordConfirm.Enabled = false;
                btnRegister.Enabled = false;
                lblMessage.Text = GetDictionaryText("Regisration is currently disabled for this site.");                
            }

        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if(txtPassword.Text != txtPasswordConfirm.Text) 
                { 
                    lblMessage.Text = GetDictionaryText("Passwords do not match");  
                } 
                else 
                { 
                    string domainUser = Sitecore.Context.Domain.GetFullName(txtEmail.Text); 

                    try 
                    { 
                        if (Sitecore.Security.Accounts.User.Exists(domainUser)) 
                        { 
                            lblMessage.Text = GetDictionaryText("Already registered");
                        }                         
                        else 
                        {                            
                            System.Web.Security.Membership.CreateUser(domainUser, txtPassword.Text, txtEmail.Text);                           
                                                         
                            if(Sitecore.Security.Authentication.AuthenticationManager.Login(domainUser, txtPassword.Text, false)) 
                            {
                                // Register Goal & set a few values in the visit tags.
                                Sitecore.Context.User.Profile.FullName = txtName.Text;
                                Sitecore.Context.User.Profile.ProfileItemId = "{93B42F5F-17A9-441B-AB6D-444F714EF384}"; //LS User
                                Sitecore.Context.User.Profile.Save();

                                Tracker.CurrentVisit.CurrentPage.Register("Register", "[Register] Username: \"" + domainUser + "\"");
                                AnalyticsHelper.SetVisitTagsOnLogin(domainUser);
                                Sitecore.Web.WebUtil.Redirect("/"); 
                            }                             
                        } 
                    }                     
                    catch(System.Web.Security.MembershipCreateUserException) 
                    { 
                        lblMessage.Text = GetDictionaryText("Unable to register");
                    } 
                }            
            }
        } 
    } 
}