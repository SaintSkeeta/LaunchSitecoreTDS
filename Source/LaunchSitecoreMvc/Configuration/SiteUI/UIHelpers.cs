using LaunchSitecore.Configuration;
using Sitecore.Data.Items;
using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Mvc.Extensions;
using Sitecore.Mvc.Presentation;
using LaunchSitecore.Models;
using Sitecore.Data;

namespace LaunchSitecore.Configuration.SiteUI
{
  public static class UIHelpers
  {
    /// <summary>
    /// Wraps the standard sitecore dictionary call.  In order to have all site labels and standard text managed within the CMS, we use the dictionary.
    /// These items simply hold the value for each label.    
    /// </summary>
    /// <param name="key">The dictionary key you are requesting.</param>
    /// <returns>The phrase value for the requested key.</returns>
    public static string GetDictionaryText(string key)
    {
      return Sitecore.Globalization.Translate.Text(key);
    }

    /// <summary>
    /// Provides the ablility to get a link to the target item of a guid type such as droptree in Sitecore.  
    /// /// </summary>
    /// <param name="item">The item that has the droptree.</param>
    /// <param name="fieldName">The name of the drop tree field.</param>
    /// <returns>the link to the item specified in the droptree</returns>
    public static string GetLink(this HtmlHelper htmlHelper, Item item, string fieldName)
    {      
      return GetLink(item, fieldName);
    }

    /// <summary>
    /// Provides the ablility to get a link to the target item of a guid type such as droptree in Sitecore.  
    /// /// </summary>
    /// <param name="item">The item that has the droptree.</param>
    /// <param name="fieldName">The name of the drop tree field.</param>
    /// <returns>the link to the item specified in the droptree</returns>
    public static string GetLink(this Item item, string fieldName)
    {
      if (item == null) return String.Empty;
      var targetItem = Sitecore.Context.Database.GetItem(item.Fields[fieldName].Value);
      if (targetItem == null) return String.Empty;
      return LinkManager.GetItemUrl(targetItem);
    }

    /// <summary>
    /// Wraps the link manager call.  
    /// /// </summary>
    /// <param name="item">The item you need a link to.</param>
    /// <returns>the link</returns>
    public static string GetLink(this HtmlHelper htmlHelper, Item item)
    {
      return LinkManager.GetItemUrl(item);
    }

    public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
    {
      return enumerable == null || !enumerable.Any();
    }

    public static bool IsLast(this IEnumerable<CustomItem> enumerable, CustomItem element)
    {
      return enumerable == null || enumerable.Last().InnerItem.ID == element.InnerItem.ID;
    }

    public static bool IsFirst(this IEnumerable<CustomItem> enumerable, CustomItem element)
    {
      return enumerable == null || enumerable.First().InnerItem.ID == element.InnerItem.ID;
    }

    public static string NormailzeId(this ID id)
    {
      return id.ToGuid().ToString("N").ToLower();
    }
  }
}