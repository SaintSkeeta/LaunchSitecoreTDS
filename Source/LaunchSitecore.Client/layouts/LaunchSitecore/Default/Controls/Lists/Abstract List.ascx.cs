using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Sitecore.Web.UI.WebControls;
using Sitecore.Data.Items;
using Sitecore.Links;
using LaunchSitecore.Configuration;
using Sitecore.Collections;

namespace LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Lists
{
    public partial class Abstract_List : Sitecore.Sharedsource.Web.UI.Sublayouts.SublayoutBase
    {
        private void Page_Load(object sender, EventArgs e)
        {   
            rptList.DataSource = base.DataSourceItem.Children; 
            rptList.DataBind();

            // if the list is empty, we need to show our message to the user in edit mode
            if (Sitecore.Context.PageMode.IsPageEditorEditing && ((ChildList)rptList.DataSource).Count == 0)
            {
                showIfEmpty.Visible = true;
            }
        }

        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Item node = (Item)e.Item.DataItem;
                
                HyperLink LinkTo = (HyperLink)e.Item.FindControl("LinkTo");
                FieldRenderer Title = (FieldRenderer)e.Item.FindControl("Title");
                FieldRenderer Abstract = (FieldRenderer)e.Item.FindControl("Abstract");
                                    
                if (LinkTo != null && Title != null && Abstract != null)
                {
                    LinkTo.NavigateUrl = LinkManager.GetItemUrl(node);
                    LinkTo.Text = SiteConfiguration.GetDictionaryText("Read More");
                    Title.Item = node;
                    Abstract.Item = node;                    
                }                
            }
        }
    }
}