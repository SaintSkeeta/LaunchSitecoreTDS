using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaunchSitecore.Configuration.AuthoringExperience.ItemNaming
{
  public class ContentEditorItemNamingNotification
  {
    const string message = "Launch Sitecore is configured to store the item name without dashes as the display name.  You cannot override the display name of this item unless you change this configuration.";
    public void Process(
      Sitecore.Pipelines.GetContentEditorWarnings.GetContentEditorWarningsArgs args)
    {
      Sitecore.Diagnostics.Assert.IsNotNull(args, "args");
      Sitecore.Data.Items.Item currentItem = args.Item;
      Sitecore.Diagnostics.Assert.IsNotNull(currentItem, "args.Item");

      if (ItemNamingHelper.AreContentEditorWarningsOn())
      {
        if (currentItem.Name != currentItem.DisplayName && ItemNamingHelper.StorePrettyNameInDisplayName() && ItemNamingHelper.HasPresentation(currentItem) && ItemNamingHelper.IsContentRoot(currentItem))
        {
          this.AddNotification(message, currentItem, args);
        }
      }
    }

    protected void AddNotification(string message, Sitecore.Data.Items.Item item, Sitecore.Pipelines.GetContentEditorWarnings.GetContentEditorWarningsArgs args)
    {
      Sitecore.Pipelines.GetContentEditorWarnings.GetContentEditorWarningsArgs.ContentEditorWarning warning = args.Add();
      warning.Title = "Item Naming";
      warning.Text = message;
      warning.Icon = "/assets/img/about.png";
    }
  }
}