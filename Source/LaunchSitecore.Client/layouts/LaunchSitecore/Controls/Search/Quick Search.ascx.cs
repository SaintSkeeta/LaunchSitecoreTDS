using Sitecore.Analytics;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.Data.Items;
using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using LaunchSitecore.Configuration.SiteUI.Base;
using Sitecore.Data;
using LaunchSitecore.Configuration.SiteUI.Search.Models;
using LaunchSitecore.Configuration;

namespace LaunchSitecore.layouts.LaunchSitecore.Controls.Search
{
  public partial class Quick_Search : SitecoreUserControlBase
  {
    private void Page_Load(object sender, EventArgs e)
    {
      string initialTag = String.Empty;

      if (!Page.IsPostBack && Session["tag"] != null && Convert.ToString(Session["tag"]) != string.Empty)
      {
        initialTag = (string)Session["tag"];
        Session["tag"] = String.Empty;
      }
        
      string searchStr = (string)Session["Search"];
      if (searchStr != null && searchStr != string.Empty)
      {
        if (searchStr != "*") searchString.Text = searchStr;
        if (!Page.IsPostBack)
        {
          performSearch(searchStr, initialTag);          

          litRefineResults.Text = GetDictionaryText("Refine Results");
          litType.Text = GetDictionaryText("Type");
          litTags.Text = GetDictionaryText("Tags");
          if (searchStr != "*") litSearchResultsFor.Text = GetDictionaryText("Search Results for");
          else litSearchResultsFor.Text = GetDictionaryText("Search Results");
        }
      }
    }

    public void performSearch(string searchStr, string initialTag)
    {
      List<Item> ResultsList = new List<Item>();
      string SelectedType = String.Empty;
      List<string> SelectedTags = new List<string>();
      string Tags = String.Empty;
      if (initialTag != String.Empty) SelectedTags.Add(initialTag);
      

      string indexname = "sitecore_master_index";
      if (Sitecore.Context.PageMode.IsNormal || Sitecore.Context.PageMode.IsDebugging) indexname = "sitecore_web_index";

      using (var context = ContentSearchManager.GetIndex(indexname).CreateSearchContext())
      {
        // only one can be selected because an item can be two types.
        foreach (ListItem l in TypeFacetCheckList.Items) { if (l.Selected) SelectedType = l.Value; }

        // multiple tags could be selected.
        foreach (ListItem l in TagsFacetCheckList.Items) { if (l.Selected) SelectedTags.Add(l.Value); }      
  
        // Start the search query building
        var query = context.GetQueryable<SitecoreItem>().Where(item => item.Path.StartsWith(Sitecore.Context.Site.StartPath));

        // we will split the spaces and require all words to be in the index.
        foreach (string word in searchStr.Split(' '))
        {
          query = query.Where(item => item.Title.Contains(word).Boost(2) || item.Content.Contains(word));                  
        }

        if (SelectedType != String.Empty) { query = query.Where(item => item.TemplateName.Equals(SelectedType)); }
        
        foreach (string s in SelectedTags) 
        {
          query = query.Where(item => item.Tags.Equals(s)); 
          Tags = Tags + "|" + Sitecore.Context.Database.GetItem(new ID(s)).Name;
        }

        var results = query
          .Filter(item => item.Language == Sitecore.Context.Language.Name)
          .Filter(item => item.HasPresentation)
          .Filter(item => item.ShowInSearchResults)
          .FacetOn(item => item.Tags).FacetOn(item => item.TemplateName).GetResults();               
        
        rptSearchResults.DataSource = results.Hits;
        rptSearchResults.DataBind();
        BindFacets(results.Facets, SelectedType, SelectedTags);

        Tags = Tags.TrimStart('|');

        if (results.TotalSearchResults == 0)
        {
          litRefineResults.Visible = false;
          litSearchResultsFor.Visible = false;
                    
          Tracker.CurrentPage.Register("No Search Hits Found", String.Format("No Search Results Found for ({0}) Type ({1}) Tags ({2})", searchStr, SelectedType, Tags));
        }
        else
        {
          Tracker.CurrentPage.Register("Search", String.Format("Search for ({0}) Type ({1}) Tags ({2}) Results ({3})", searchStr, SelectedType, Tags, results.TotalSearchResults));
        }
      }
    }

    protected void rptSearchResults_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
      {
        SearchHit<SitecoreItem> item = (SearchHit<SitecoreItem>)e.Item.DataItem;
        {
          HyperLink ItemLink = (HyperLink)e.Item.FindControl("ItemLink");
          Literal ItemDescription = (Literal)e.Item.FindControl("ItemDescription");

          if (ItemLink != null && ItemDescription != null)
          {
            Item i = item.Document.GetItem();
            ItemLink.NavigateUrl = LinkManager.GetItemUrl(i);
            if (i["menu title"] != string.Empty) ItemLink.Text = i["menu title"];
            else if (i["title"] != string.Empty) ItemLink.Text = i["title"];
            else ItemLink.Text = i.Name;

            ItemDescription.Text = SiteConfiguration.GetPageDescripton(i);
          }
        }
      }
    }

    protected void BindFacets(FacetResults facets, String types, List<string> tags)
    {
      litType.Visible = true;
      litTags.Visible = true;  

      foreach (FacetCategory fc in facets.Categories)
      {
        if (fc.Name == "_templatename")
        {
          TypeFacetCheckList.Items.Clear();
          if (fc.Values.Count == 0) litType.Visible = false;

          foreach (var a in fc.Values)
          {
            ListItem  li = new ListItem(String.Format("{0} ({1})", a.Name, a.AggregateCount), a.Name);
            if (li.Value == types) li.Selected = true;
            TypeFacetCheckList.Items.Add(li);            
          }
        }

        if (fc.Name == "__semantics")
        {
          TagsFacetCheckList.Items.Clear();
          if (fc.Values.Count == 0) litTags.Visible = false;  

          foreach (var a in fc.Values)
          {
            Item tag = Sitecore.Context.Database.GetItem(new ID(a.Name));
            ListItem li = new ListItem(String.Format("{0} ({1})", tag.Name, a.AggregateCount), a.Name);
            if (tags.Contains(li.Value)) li.Selected = true;
            TagsFacetCheckList.Items.Add(li);
          }
        }
      }
    }

    protected void TypeFacets_SelectedIndexChanged(object sender, EventArgs e)
    {
      performSearch(searchString.Text, String.Empty);
    }

    protected void TagFacets_SelectedIndexChanged(object sender, EventArgs e)
    {
      performSearch(searchString.Text, String.Empty);
    }
  }
}