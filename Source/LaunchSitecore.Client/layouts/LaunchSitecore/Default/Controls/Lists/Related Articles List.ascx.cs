using System;
using Sitecore.Data.Comparers;
using System.Web.UI.WebControls;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Web.UI.WebControls;
using Sitecore.Resources.Media;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using LaunchSitecore.Configuration;

namespace LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Lists
{  
    public partial class Related_Articles_List : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            List<Item> backgroundItems = new List<Item>();
            List<Item> digDeeperItems = new List<Item>();

            //first get items related to me...
            MultilistField related = Sitecore.Context.Item.Fields["Prerequisite Articles"];
            if (related != null)
            {
                foreach (Item i in related.GetItems())
                {
                    backgroundItems.Add(i);
                }
            }

            if (backgroundItems.Count > 0)
            {
                backgroundItems.Sort(new ItemSorterByTitle());
                rptBackground.DataSource = backgroundItems;
                rptBackground.DataBind();
            }

            //now get items I am related to
            foreach (Item i in Sitecore.Context.Database.SelectItems(SiteConfiguration.GetFurtherReadingArticlesQuery(Sitecore.Context.Item.ID.ToString())))
            {
                digDeeperItems.Add(i);
            }

            if (digDeeperItems.Count > 0)
            {
                digDeeperItems.Sort(new ItemSorterByTitle());
                rptDigDeeper.DataSource = digDeeperItems;
                rptDigDeeper.DataBind();
            }
        }

        protected void rptRelated_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                Literal SectionTitle = (Literal)e.Item.FindControl("SectionTitle");

                if (((Repeater)sender).ID == "rptBackground")
                {
                    SectionTitle.Text = SiteConfiguration.GetDictionaryText("Background Articles");
                }
                else // must be the Dig Deeper Repeater
                {
                    SectionTitle.Text = SiteConfiguration.GetDictionaryText("Further Reading");
                }                
            }

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Item node = (Item)e.Item.DataItem;
                {
                    HyperLink RelatedLink = (HyperLink)e.Item.FindControl("RelatedLink");
                    FieldRenderer RelatedName = (FieldRenderer)e.Item.FindControl("RelatedName");

                    if (RelatedLink != null && RelatedName != null)
                    {
                        RelatedLink.NavigateUrl = LinkManager.GetItemUrl(node);                    
                        RelatedName.Item = node;
                    }
                }
            }
        }        
    }
}