using Sitecore.Shell.Applications.ContentEditor.Gutters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaunchSitecore.Configuration.AuthoringExperience.ContentEditor
{
  public class NoVersionInCurrentLanguageGutter : Sitecore.Shell.Applications.ContentEditor.Gutters.GutterRenderer
  {
    protected override GutterIconDescriptor GetIconDescriptor(Sitecore.Data.Items.Item item)
    {
      if (item.Versions.Count == 0)
      {
        var descriptor = new GutterIconDescriptor();
        descriptor.Icon = "Applications/32x32/scroll_delete.png";
        descriptor.Tooltip = "No version of this item exists in the current language.";
        return descriptor;
      }

      return null;
    }
  }
}


