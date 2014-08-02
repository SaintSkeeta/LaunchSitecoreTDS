using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LaunchSitecore.Models;
using LaunchSitecore.Configuration.SiteUI.Analytics;
using Sitecore.Analytics;
using LaunchSitecore.Configuration.SiteUI.Base;
using Sitecore.Analytics.Model.Entities;
using Sitecore.Analytics.Tracking;
using Sitecore.Diagnostics;

namespace LaunchSitecore.Controllers
{
  [Authorize]
  //[InitializeSimpleMembership]
  public class AccountController : LaunchSitecoreBaseController 
  {
    //
    // GET: /Account/Login
    [AllowAnonymous]
    public ActionResult Login(string returnUrl)
    {
      ViewBag.ReturnUrl = returnUrl;
      return View();
    }

    //
    // POST: /Account/Login
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public ActionResult Login(LoginModel model, string returnUrl)
    {
      if (ModelState.IsValid)
      {
        Sitecore.Security.Domains.Domain domain = Sitecore.Context.Domain;
        string domainUser = domain.Name + @"\" + model.UserName;
        if (Sitecore.Security.Authentication.AuthenticationManager.Login(domainUser, model.Password, model.RememberMe))
        {
          // identify the user (Username is Email)
          Tracker.Current.Session.Identify(model.UserName);

          // Register Goal & set a few values in the visit tags.
          Tracker.Current.CurrentPage.Register("Login", "[Login] Username: \"" + domainUser + "\"");
          AnalyticsHelper.SetVisitTagsOnLogin(domainUser);
          return RedirectToLocal(returnUrl);
        }
      }

      // If we got this far, something failed, redisplay form
      ModelState.AddModelError("", "The user name or password provided is incorrect.");
      return View(model);
    }

    //
    // POST: /Account/LogOff
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult LogOff()
    {
      Sitecore.Security.Authentication.AuthenticationManager.Logout();
      
      // calling Session Abandon flushes the session data out to the xDB
      Session.Abandon();
      Sitecore.Web.WebUtil.Redirect("/");
      return null;
    }

    //
    // GET: /Account/Register
    [AllowAnonymous]
    public ActionResult Register()
    {
      return View();
    }

    //
    // POST: /Account/Register
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public ActionResult Register(RegisterModel model)
    {
      if (ModelState.IsValid)
      {
        try
        {
          if (model.Password != model.ConfirmPassword) throw new ApplicationException(GetDictionaryText("Passwords do not match"));

          string domainUser = Sitecore.Context.Domain.GetFullName(model.Email);
          if (Sitecore.Security.Accounts.User.Exists(domainUser)) throw new ApplicationException(GetDictionaryText("Already registered"));

          System.Web.Security.Membership.CreateUser(domainUser, model.Password, model.Email);

          if (Sitecore.Security.Authentication.AuthenticationManager.Login(domainUser, model.Password, false))
          {
            // Register Goal & set a few values in the visit tags.
            Sitecore.Context.User.Profile.FullName = model.FullName;
            Sitecore.Context.User.Profile.ProfileItemId = "{93B42F5F-17A9-441B-AB6D-444F714EF384}"; //LS User
            Sitecore.Context.User.Profile.Save();

            // identify the user (which should add them)
            Tracker.Current.Session.Identify(model.Email);

            Contact contact = Sitecore.Analytics.Tracker.Current.Contact;
            try
            {
                // set the personal information for the contact
                IContactPersonalInfo personalInfo = contact.GetFacet<IContactPersonalInfo>("Personal");
                personalInfo.FirstName = model.FullName.Split(' ')[0];
                personalInfo.Surname = model.FullName.Split(' ')[1];
            }
            catch (Exception ex)
            {
                Log.Error("Error setting the User's Personal Info: " + ex.ToString(), this);
            }

            try
            {
                // set the email address
                IContactEmailAddresses emailAddresses = contact.GetFacet<IContactEmailAddresses>("Emails");
                emailAddresses.Preferred = model.Email;

                if (!emailAddresses.Entries.Contains(model.Email))
                {
                    emailAddresses.Entries.Create(model.Email);
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error assigning email address: " + ex.ToString(), this);
            }

            Tracker.Current.CurrentPage.Register("Register", "[Register] Username: \"" + domainUser + "\"");
            AnalyticsHelper.SetVisitTagsOnLogin(domainUser);
            Sitecore.Web.WebUtil.Redirect("/");
          }
        }
        catch (System.Web.Security.MembershipCreateUserException)
        {
          ModelState.AddModelError("", GetDictionaryText("Unable to register"));
        }
        catch (ApplicationException ex)
        {
          ModelState.AddModelError("", ex.Message);
        }
      }
      // If we got this far, something failed, redisplay form
      return View(model);
    }

    #region Helpers
    private ActionResult RedirectToLocal(string returnUrl)
    {
      if (Url.IsLocalUrl(returnUrl))
      {
        return Redirect(returnUrl);
      }
      else
      {
        return Redirect("/");
      }
    }    
    #endregion
  }
}
