using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Security.Accounts;
using System.Web.Security;
using Sitecore.Web.UI.WebControls;
using Sitecore.SecurityModel;
using System.Collections.Generic;
using Sitecore.Security.AccessControl;
using Sitecore.Security;
using System;
using Sitecore.Configuration;

namespace LaunchSitecore.Configuration.AuthoringExperience.ItemNaming
{
  public class UpdateItemNamesCommand : Command
  {
    public override void Execute(CommandContext context)
    {
      //Disable security and create accounts
      using (new SecurityDisabler())
      {
        Database master = Factory.GetDatabase("master");
        Item content = master.GetItem("/sitecore/content");
        ItemNamingHelper.RecursiveItemSave(content, true);
      }
    }
  }
}