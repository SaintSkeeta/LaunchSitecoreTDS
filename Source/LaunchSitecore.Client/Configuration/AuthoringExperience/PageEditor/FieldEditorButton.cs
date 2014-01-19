using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Sitecore.Data;
using Sitecore.Diagnostics;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.Sheer;
using Sitecore;
using Sitecore.Web;

namespace LaunchSitecore.Configuration.AuthoringExperience.PageEditor
{
    public class FieldEditorButton : Sitecore.Shell.Applications.WebEdit.Commands.FieldEditorCommand
    {
        /// <summary>
        /// The name of the parameter in <c>ClientPipelineArgs</c> containing 
        /// Sitecore item identification information.
        /// </summary>
        private const string URI = "uri";
        
        public override void Execute(CommandContext context)
        {
            Assert.ArgumentNotNull(context, "context");
            if (context.Items.Length >= 1)
            {
                ClientPipelineArgs args = new ClientPipelineArgs(context.Parameters);
                args.Parameters.Add("uri", context.Items[0].Uri.ToString());
                if (args.Parameters["flds"] == String.Empty) { args.Parameters.Add("flds", context.Parameters["flds"]); }
                Context.ClientPage.Start(this, "StartFieldEditor", args);                 
            }
        }

        /// <summary>
        /// Retrieve field editor options controlling the field editor,
        /// including the fields displayed.
        /// </summary>
        /// <param name="args">Pipeline arguments.</param>
        /// <param name="form">Form parameters.</param>
        /// <returns>Field editor options.</returns>
        protected override Sitecore.Shell.Applications.WebEdit.PageEditFieldEditorOptions GetOptions(Sitecore.Web.UI.Sheer.ClientPipelineArgs args,NameValueCollection form)
        {
            Sitecore.Diagnostics.Assert.IsNotNull(args, "args");
            Sitecore.Diagnostics.Assert.IsNotNull(form, "form");
            Sitecore.Diagnostics.Assert.IsNotNullOrEmpty(args.Parameters[URI], URI);            
            Sitecore.Data.ItemUri uri = Sitecore.Data.ItemUri.Parse(args.Parameters[URI]);
            Sitecore.Diagnostics.Assert.IsNotNull(uri, URI);
            Sitecore.Diagnostics.Assert.IsNotNullOrEmpty(args.Parameters["flds"], "flds");
            string flds = args.Parameters["flds"];
            
            Sitecore.Data.Items.Item item = Sitecore.Data.Database.GetItem(uri);
            Sitecore.Diagnostics.Assert.IsNotNull(item, "item");

            List<Sitecore.Data.FieldDescriptor> fields = new List<Sitecore.Data.FieldDescriptor>();
                    
            foreach (string fieldName in flds.Split('|'))
            {
                if (item.Fields[fieldName] != null)
                {                    
                    fields.Add(new Sitecore.Data.FieldDescriptor(item, item.Fields[fieldName].Name));
                }
            }           

            // Field editor options.
            Sitecore.Shell.Applications.WebEdit.PageEditFieldEditorOptions options = new Sitecore.Shell.Applications.WebEdit.PageEditFieldEditorOptions(form, fields);
            options.PreserveSections = false;
            options.DialogTitle = "Update Item";
            options.Icon = item.Appearance.Icon;
            
            return options;
        }

        /// <summary>
        /// Determine if the command button should be displayed or hidden.
        /// </summary>
        public override CommandState QueryState(CommandContext context)
        {            
            if (WebUtil.GetQueryString("mode") != "edit")
            {
                return CommandState.Hidden;
            }
            return CommandState.Enabled;  
        }
    }
}