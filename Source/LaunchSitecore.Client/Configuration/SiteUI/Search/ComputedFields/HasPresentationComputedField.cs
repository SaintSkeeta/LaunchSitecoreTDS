using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Data.Managers;

// This is an example of a computed field in Sitecore.  It is added to the index as the item is saved just like standard fields.
// I wanted an easy way to determine if an Item had a layout specified so I can exclude it from results if needed on the public site.
namespace LaunchSitecore.Configuration.SiteUI.Search.ComputedFields
{
  public class HasPresentationComputedField : IComputedIndexField
  {
    public string FieldName { get; set; }

    public string ReturnType { get; set; }

    public object ComputeFieldValue(IIndexable indexable)
    {
      Item i = ((Item)(indexable as SitecoreIndexableItem));
      if (i.Visualization.Layout != null) return true;
      return null;
    }
  }
}