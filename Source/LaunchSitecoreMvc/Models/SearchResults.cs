using LaunchSitecore.Configuration;
using LaunchSitecore.Configuration.Search.Models;
using Sitecore.Analytics;
using Sitecore.ContentSearch;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Links;
using Sitecore.ContentSearch.Linq;

namespace LaunchSitecore.Models
{
  public class SearchResults
  {
    public string SearchString { get; set; }

    public string[] SelectedFacets
    {
      get { return null; }
    }

    public List<SimpleItem> Results { get; set; }

    public List<Facet> Facets { get; set; }

    public SearchResults (string searchStr, string[] facets)
    {
      // if we don't have a searchStr for some reason...
      if (searchStr == string.Empty) searchStr = "*";

      List<Item> ResultsList = new List<Item>();

      string indexname = "sitecore_master_index";
      if (Sitecore.Context.PageMode.IsNormal || Sitecore.Context.PageMode.IsDebugging) indexname = "sitecore_web_index";

      using (var context = ContentSearchManager.GetIndex(indexname).CreateSearchContext())
      {
        // Start the search query building
        var query = context.GetQueryable<SitecoreItem>().Where(item => item.Path.StartsWith(Sitecore.Context.Site.StartPath));

        // we will split the spaces and require all words to be in the index.
        foreach (string word in searchStr.Split(' '))
        {
          query = query.Where(item => item.Title.Contains(word) || item.Content.Contains(word));
        }

        if (facets != null)
        {
          foreach (string facet in facets)
          {
            if (facet.Contains("|"))
            {
              string[] values = facet.Split('|');
              string val = values[1];
              if (values[0] == SiteConfiguration.GetDictionaryText("Type")) { query = query.Where(item => item.TemplateName.Equals(val)); }
              if (values[0] == SiteConfiguration.GetDictionaryText("Tags")) { query = query.Where(item => item.Tags.Equals(val)); }
            }
          }
        }

        var results = query
          .Filter(item => item.Language == Sitecore.Context.Language.Name)
          .Filter(item => item.HasPresentation)
          .Filter(item => item.ShowInSearchResults)
          .FacetOn(item => item.Tags).FacetOn(item => item.TemplateName)
          .GetResults();

        this.Results = new List<SimpleItem>();
        this.Facets = new List<Facet>();

        this.SearchString = searchStr;
        foreach (SearchHit<SitecoreItem> result in results.Hits)
        { 
          this.Results.Add(new SimpleItem(result.Document.GetItem()));
        }

        foreach (FacetCategory fc in results.Facets.Categories)
        {
          Facet f = new Facet();          
          f.Items = new List<FacetItem>();          

          if (fc.Name == "_templatename")
          {
            f.FacetName = SiteConfiguration.GetDictionaryText("Type");
            foreach (var a in fc.Values)
            {
              f.Items.Add(new FacetItem(a.Name, String.Format("{0} ({1})", a.Name, a.AggregateCount), false));
            }            
          }

          if (fc.Name == "__semantics")
          {
            f.FacetName = SiteConfiguration.GetDictionaryText("Tags");
            foreach (var a in fc.Values)
            {
              Item tag = Sitecore.Context.Database.GetItem(new ID(a.Name));
              f.Items.Add(new FacetItem(a.Name, String.Format("{0} ({1})", tag.Name, a.AggregateCount), false));
            }
          }

          // set the correct facet entries to selected
          if (facets != null)
          {
            foreach (string facet in facets)
            {
              if (facet.Contains("|"))
              {
                string[] values = facet.Split('|');
                if (values[0] == f.FacetName)
                {
                  foreach (FacetItem fi in f.Items) { if (fi.Id == values[1]) fi.Selected = true; }
                }
              }
            }
          }

          if (f.Items.Count > 0) this.Facets.Add(f);
        }
      }
    }
  }

  public class Facet 
  {
    public Facet() { }
    public string FacetName { get; set; }
    public List<FacetItem> Items { get; set; } 
  }

  public class FacetItem
  {
    public FacetItem() { }
    public FacetItem(string id, string name, bool selected)
    {
      Id = id;
      Name = name;
      Selected = selected;
    }
    public string Id { get; set; }
    public string Name { get; set; }
    public bool Selected { get; set; }
  }
}