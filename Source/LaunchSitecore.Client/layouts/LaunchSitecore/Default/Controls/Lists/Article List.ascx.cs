using System;
using System.Web.UI.WebControls;
using Sitecore.Web.UI.WebControls;
using LaunchSitecore.Configuration;
using System.Collections.Generic;
using Sitecore.Data.Items;
using Sitecore.Links;

namespace LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Lists
{  
    public partial class Article_List : Sitecore.Sharedsource.Web.UI.Sublayouts.SublayoutBase
    {
        private void Page_Load(object sender, EventArgs e)
        { 
            string query;            
            
            if (Sitecore.Context.Item.Template.Key == "contributor")
            {
                query = SiteConfiguration.GetArticlesByContributor(Sitecore.Context.Item.ID.ToString());
                // we need to just get all of the articles for a contributor unless it was overrridden.
                if (DataSourceItem.ID == Sitecore.Context.Item.ID) { DataSourceItem = SiteConfiguration.GetArticlesRootItem(); }
            }
            else
            {
                query = SiteConfiguration.GetArticles();
            }                     

            // get items by the current contributor...
            List<Item> articles = new List<Item>();
            Item[] items = DataSourceItem.Axes.SelectItems(query);
            if (items != null)
            {
                foreach (Item i in items)
                {
                    articles.Add(i);
                }       

                // we have articles or the items array would have been null
                articles.Sort(new ItemSorterByTitle());
                rptArticles.DataSource = articles;
                rptArticles.DataBind();
            }
            else
            {
                if (Sitecore.Context.PageMode.IsPageEditorEditing)
                {
                    showIfEmpty.Visible = true;
                }
            }
        }

        protected void rptArticles_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                Literal SectionTitle = (Literal)e.Item.FindControl("SectionTitle");
                SectionTitle.Text = SiteConfiguration.GetDictionaryText("Articles");
            }

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Item node = (Item)e.Item.DataItem;
                {
                    HyperLink ArticleLink = (HyperLink)e.Item.FindControl("ArticleLink");
                    FieldRenderer ArticleName = (FieldRenderer)e.Item.FindControl("ArticleName");

                    if (ArticleLink != null && ArticleName != null)
                    {
                        ArticleLink.NavigateUrl = LinkManager.GetItemUrl(node);
                        ArticleName.Item = node;
                    }
                }
            }
        }
    }
}