using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web;
using Sitecore.Data.Items;
using Sitecore.Data;

namespace LaunchSitecore.Configuration.AuthoringExperience.PageEditor.Base
{
    class FieldEditorButtonForSingleField : FieldEditorButton
    {
        /// <summary>
        /// Determine if the command button should be displayed or hidden.
        /// </summary>
        public CommandState QueryState(CommandContext context, string fieldname)
        {            
            if (context.Items.Length > 0 && 
                context.Items[0] != null &&
                context.Items[0].Fields[fieldname] != null)
            {
                if (WebUtil.GetQueryString("mode") != "edit")
                {
                    return CommandState.Disabled;
                }
                return CommandState.Enabled;
            }           
            
            return CommandState.Hidden;
        }
    }
}
