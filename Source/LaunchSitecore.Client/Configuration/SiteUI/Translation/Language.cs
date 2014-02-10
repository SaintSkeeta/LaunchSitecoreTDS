using Sitecore.Data.Items;
using Sitecore.Globalization;
using Sitecore.Text;
using Sitecore.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaunchSitecore.Configuration.SiteUI.Translation
{
  public class SiteLanguage
  {
    public static Item GetLanguageRoot()
    {
      Item languageRoot = Sitecore.Context.Database.GetItem("/sitecore/system/languages");
      return languageRoot;
    }

    public static List<Item> GetAdditionalLanguages(Language currentLanguage)
    {
      Item languageRoot = GetLanguageRoot();
      List<Item> languages = new List<Item>();
      foreach (Item i in languageRoot.Children)
      {
        if (i.Name != currentLanguage.Name) languages.Add(i); 
      }
      return languages;
    }

    public static string GetLanguageUrl(Item item)
    {
      UrlString url = new UrlString(WebUtil.GetRawUrl());
      url["sc_lang"] = item.Name;
      return url.ToString();
    }
  }
}