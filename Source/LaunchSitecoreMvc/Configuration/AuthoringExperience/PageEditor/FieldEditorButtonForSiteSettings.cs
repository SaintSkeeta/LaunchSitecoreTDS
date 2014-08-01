using Sitecore;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web;
using Sitecore.Web.UI.Sheer;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace LaunchSitecore.Configuration.AuthoringExperience.PageEditor
{
  public class FieldEditorButtonForSiteSettings : FieldEditorButton
  {
    public override void Execute(CommandContext context)
    {
      Assert.ArgumentNotNull(context, "context");
      if (context.Items.Length >= 1)
      {
        // Get the item this button needs
        Item current = Sitecore.Data.Database.GetItem(context.Items[0].Uri);
        Item home = SiteConfiguration.GetHomeItem(current);
        Database db = Factory.GetDatabase("master");
        Item pres = db.GetItem(String.Format("{0}/Configuration/Site Settings", home.Paths.FullPath), current.Language);

        ClientPipelineArgs args = new ClientPipelineArgs(context.Parameters);
        args.Parameters.Add("uri", pres.Uri.ToString());
        if (args.Parameters["flds"] == String.Empty) { args.Parameters.Add("flds", context.Parameters["flds"]); }
        Context.ClientPage.Start(this, "StartFieldEditor", args);
      }
    }
  }
}