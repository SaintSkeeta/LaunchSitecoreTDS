using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web;
using Sitecore.Data.Items;
using Sitecore.Data;
using LaunchSitecore.Configuration.AuthoringExperience.PageEditor.Base;

namespace LaunchSitecore.Configuration.AuthoringExperience.PageEditor
{
    class FieldEditorButtonForArticleTemplate : FieldEditorButtonForTemplate
    {
        /// <summary>
        /// Determine if the command button should be displayed or hidden.
        /// </summary>
        public override CommandState QueryState(CommandContext context)
        {
            return base.QueryState(context, "article");
        }
    }
}
