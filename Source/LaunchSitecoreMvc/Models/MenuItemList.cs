using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Mvc;
using Sitecore.Mvc.Presentation;
using System.Xml.Serialization;
using Sitecore.Data.Items;
using Sitecore.Links;
using LaunchSitecore.Configuration;

namespace LaunchSitecore.Models
{
  // This is used when I am using the Sitecore pipeline to supply the model to the view
  public class MenuItemList : IRenderingModel
  {
    public List<MenuItem> menuItems { get; protected set; }

    public void Initialize(Sitecore.Mvc.Presentation.Rendering rendering)
    {      
      LoadMenuItems();
    }

    public void LoadMenuItems()
    {
      menuItems = new List<MenuItem>();

      Item homeItem = LaunchSitecore.Configuration.SiteConfiguration.GetHomeItem();
      if (homeItem != null)
      {
        if (homeItem["Show Item in Menu"] == "1") menuItems.Add(new MenuItem(homeItem));
        foreach (Item item in homeItem.GetChildren().Where(x => x["Show Item in Menu"].Equals("1") && SiteConfiguration.DoesItemExistInCurrentLanguage(x)))
        {         
            menuItems.Add(new MenuItem(item));
        }
      }
    }
  }
}