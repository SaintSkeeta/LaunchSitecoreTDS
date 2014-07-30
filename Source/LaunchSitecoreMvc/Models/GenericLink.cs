using LaunchSitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaunchSitecore.Models
{
  public class GenericLink
  {
    public GenericLink(string title, string url, bool openInBlankWindow)
    {
      Title = title;
      Url = url;
      OpenInBlankWindow = openInBlankWindow;      
    }

    public string Title
    {
      get;
      set;
    }

    public string Url
    {
      get;
      set;
    }

    public bool OpenInBlankWindow
    {
      get;
      set;
    }  
  }
}