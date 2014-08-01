using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;

namespace LaunchSitecore.Configuration.SiteUI.Search.Models
{
  public class SitecoreItem : SearchResultItem
  {
    public string Title { get; set; }

    [IndexField("__smallcreateddate")]
    public DateTime PublishDate { get; set; }

    [IndexField("has_presentation")]
    public bool HasPresentation { get; set; }

    [IndexField(BuiltinFields.Semantics)]
    public string Tags { get; set; }

    [IndexField("show_in_search_results")]
    public bool ShowInSearchResults { get; set; }
  }
}