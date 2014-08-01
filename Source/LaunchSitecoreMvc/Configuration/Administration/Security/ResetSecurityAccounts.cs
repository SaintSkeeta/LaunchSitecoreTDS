using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Security.Accounts;
using System.Web.Security;
using Sitecore.Web.UI.WebControls; 

namespace LaunchSitecore.Configuration.Administration.Security
{        
    public class ResetSecurityAccounts : Command
    {
        public override void Execute(CommandContext context)
        {
            ResetUser.ResetUserAccount("sitecore\\Audrey", "a");
            ResetUser.ResetUserAccount("sitecore\\Bill", "b");
            ResetUser.ResetUserAccount("sitecore\\Lonnie", "l");
            ResetUser.ResetUserAccount("sitecore\\Minnie", "m");
            ResetUser.ResetUserAccount("sitecore\\Denny", "d");

            AjaxScriptManager.Current.Dispatch("usermanager:refresh");            
        }        
    }
}