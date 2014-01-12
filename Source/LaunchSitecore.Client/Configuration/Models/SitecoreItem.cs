using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;

namespace LaunchSitecore.Configuration.Models
{
  public class SitecoreItem : SearchResultItem
  {
    public string Title { get; set; }
    
    [IndexField(BuiltinFields.DataSource)]
    public string Datasource { get; set; }
        
    [IndexField("has_presentation")]
    public bool HasPresentation { get; set; }
  }
}