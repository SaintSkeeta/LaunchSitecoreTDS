using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Sitecore.Data;
using Sitecore.Diagnostics;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.Sheer;
using Sitecore;
using Sitecore.Web;
using Sitecore.Text;
using Sitecore.ExperienceEditor.Speak.Server.Requests;
using Sitecore.ExperienceEditor.Speak.Server.Contexts;
using Sitecore.Shell.Applications.ContentManager;
using Sitecore.ExperienceEditor.Speak.Server.Responses;
using Sitecore.Data.Items;
using Sitecore.Configuration;

namespace LaunchSitecore.Configuration.AuthoringExperience.PageEditor
{
    public class GenerateFieldEditorUrl : PipelineProcessorRequest<ItemContext>
    {
        public string GenerateUrl()
        {
            var fieldList = CreateFieldDescriptors(RequestContext.Argument.ToLower());
            var fieldeditorOption = new FieldEditorOptions(fieldList);
            //Save item when ok button is pressed
            fieldeditorOption.SaveItem = true;
            return fieldeditorOption.ToUrlString().ToString();
        }

        private List<FieldDescriptor> CreateFieldDescriptors(string accessKey)
        {
            Item editItem = this.RequestContext.Item;
            if (accessKey == "presentation" || accessKey == "configuration")
            {
                Item home = SiteConfiguration.GetHomeItem(this.RequestContext.Item);
                Database db = Factory.GetDatabase("master");
                editItem = db.GetItem(String.Format("{0}/Configuration", home.Paths.FullPath), this.RequestContext.Item.Language);
            }
            
            // Site Logo | Header Color
            var fieldList = new List<FieldDescriptor>();
            
            switch (accessKey)
            {
                case "common":
                    if (editItem.Template.GetField(new ID("{00E1D306-96BD-4B32-85B4-CD63C53CC6C1}")) != null) fieldList.Add(new FieldDescriptor(editItem, "Abstract"));
                    if (editItem.Template.GetField(new ID("{2B60D8C1-81DB-45A7-B1CB-654CDDA96AE3}")) != null) fieldList.Add(new FieldDescriptor(editItem, "Icon"));
                    if (editItem.Template.GetField(new ID("{82D725ED-6707-4532-86A6-5444E34332FD}")) != null) fieldList.Add(new FieldDescriptor(editItem, "Contributors"));
                    break;
                case "menu":
                    fieldList.Add(new FieldDescriptor(editItem, "Menu Title"));
                    fieldList.Add(new FieldDescriptor(editItem, "Show Item In Menu"));
                    fieldList.Add(new FieldDescriptor(editItem, "Show Children In Menu"));
                    fieldList.Add(new FieldDescriptor(editItem, "Show Item In Secondary Menu"));
                    fieldList.Add(new FieldDescriptor(editItem, "Show Item In Footer Menu"));
                    fieldList.Add(new FieldDescriptor(editItem, "Show In Search Results"));
                    break;
                case "presentation":
                    fieldList.Add(new FieldDescriptor(editItem, "Header Color"));
                    fieldList.Add(new FieldDescriptor(editItem, "Menu Color"));
                    fieldList.Add(new FieldDescriptor(editItem, "Site Color"));
                    fieldList.Add(new FieldDescriptor(editItem, "Footer Color"));
                    fieldList.Add(new FieldDescriptor(editItem, "Copyright Background Color"));
                    fieldList.Add(new FieldDescriptor(editItem, "Layout Style"));
                    fieldList.Add(new FieldDescriptor(editItem, "Background Color"));
                    break;
                case "configuration":
                    fieldList.Add(new FieldDescriptor(editItem, "Visible Profiles"));
                    fieldList.Add(new FieldDescriptor(editItem, "Page Title for Home and Site Sections"));
                    fieldList.Add(new FieldDescriptor(editItem, "Page Title for Lower Pages"));
                    break;
            }
            
            return fieldList;
        }

        public override PipelineProcessorResponseValue ProcessRequest()
        {
            return new PipelineProcessorResponseValue
            {
                Value = GenerateUrl()
            };
        }
    }
}