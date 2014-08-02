using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LaunchSitecore.Models;
using LaunchSitecore.Configuration.SiteUI.Analytics;
using Sitecore.Analytics;
using LaunchSitecore.Configuration.SiteUI.Base;

namespace LaunchSitecore.Controllers
{
  public class FavoritesController : LaunchSitecoreBaseController 
  {
    public ActionResult AddToFavorites()
    {
      return Sitecore.Context.User.IsAuthenticated ? View("AddToFavorites", IsAddToFavorites) : null;
    }

    [HttpPost]
    public ActionResult AddToFavorites(string itemId)
    {
      try
      {
        Sitecore.Security.Accounts.User user = Sitecore.Context.User;
        Sitecore.Security.UserProfile profile = user.Profile;
        string favorites = profile.GetCustomProperty("Favorites");

        // determine if we are adding or removing.  
        // We don't know the text of the button because it is managed in the CMS, so we will see it is already a favorite.            
        if (favorites.Contains(Sitecore.Context.Item.ID.ToString()))
        {
          favorites = favorites.Replace(Sitecore.Context.Item.ID.ToString(), String.Empty);
          favorites = favorites.Replace("||", "|"); // when removing we may leave a double pipe
          if (favorites == "|") { favorites = String.Empty; }
        }
        else // it must be an add
        {
          if (favorites == String.Empty) { favorites = Sitecore.Context.Item.ID.ToString(); }
          else { favorites = favorites + "|" + Sitecore.Context.Item.ID.ToString(); }

          // Capture the goal
          Tracker.Current.CurrentPage.Register("Add a Favorite", "[Add a Favorite] : \"" + Sitecore.Context.Item.Name + "\"");
        }

        profile.SetCustomProperty("Favorites", favorites);
        profile.Save();
      }
      catch { }
      return View("AddToFavorites", IsAddToFavorites);
    }

    private bool IsAddToFavorites
    {
      get {
        try  // just in case the profile doesn't have a favorites property.
        {
          if (Sitecore.Context.User.IsAuthenticated &&
            Sitecore.Context.User.Profile.GetCustomProperty("Favorites").Contains(Sitecore.Context.Item.ID.ToString()))
            return false;
        }
        catch { }
        return true;
      }
    }
  }
}
