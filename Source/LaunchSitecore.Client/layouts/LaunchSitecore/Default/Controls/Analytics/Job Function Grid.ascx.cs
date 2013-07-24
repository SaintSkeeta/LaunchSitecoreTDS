using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Sitecore.Web.UI.WebControls;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Collections;
using LaunchSitecore.Configuration;

namespace LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Analytics
{
    public partial class Job_Function_Grid : Sitecore.Sharedsource.Web.UI.Sublayouts.SublayoutBase
    {
        private void Page_Load(object sender, EventArgs e)
        {
            if (SiteConfiguration.GetJobFunctionItem() != null)
            {
                rptList.DataSource = SiteConfiguration.GetJobFunctionItem().Children;
                rptList.DataBind();
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
                Sitecore.Web.UI.WebControls.Image Image = (Sitecore.Web.UI.WebControls.Image)e.Item.FindControl("Image");

                if (LinkTo != null && Image != null && Title != null && Abstract != null)
                {
                    LinkTo.NavigateUrl = LinkManager.GetItemUrl(node);
                    Title.Item = node;
                    Abstract.Item = node;
                    Image.Item = node;
                }
            }
        }
    }
}