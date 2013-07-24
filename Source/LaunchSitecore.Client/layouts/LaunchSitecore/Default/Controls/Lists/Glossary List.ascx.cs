using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Sitecore.Web.UI.WebControls;
using Sitecore.Data.Items;
using Sitecore.Links;
using LaunchSitecore.Configuration;

namespace LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Lists
{
    public partial class Glossary_List : Sitecore.Sharedsource.Web.UI.Sublayouts.SublayoutBase
    {
        private void Page_Load(object sender, EventArgs e)
        {
            rptTerms.DataSource = SiteConfiguration.GetGlossaryItem().Children;        
            rptTerms.DataBind();
        }

        protected void rptTerms_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Item node = (Item)e.Item.DataItem;
                {
                    HyperLink TermLink = (HyperLink)e.Item.FindControl("TermLink");
                    FieldRenderer Term = (FieldRenderer)e.Item.FindControl("Term");
                    FieldRenderer Definition = (FieldRenderer)e.Item.FindControl("Definition");
                    FieldRenderer Icon = (FieldRenderer)e.Item.FindControl("Icon");

                    if (TermLink != null && Term != null && Definition != null && Icon != null)
                    {
                        TermLink.NavigateUrl = LinkManager.GetItemUrl(node);
                        Term.Item = node;
                        Definition.Item = node;
                        Icon.Item = node;
                    }
                }
            }
        }
    }
}