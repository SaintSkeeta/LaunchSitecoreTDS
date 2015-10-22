using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Items;

// This is an example of a computed field in Sitecore.  It is added to the index as the item is saved just like standard fields.
// I wanted an easy way to determine if an Item had a layout specified so I can exclude it from results if needed on the public site.
namespace LaunchSitecore.Configuration.Search.ComputedFields
{
  public class SiteAreaComputedField : IComputedIndexField
  {
    public string FieldName { get; set; }

    public string ReturnType { get; set; }

    public object ComputeFieldValue(IIndexable indexable)
    {
      try
      {
        Item i = ((Item)(indexable as SitecoreIndexableItem));
        while (i.Parent != null && i.Parent.Key != "home")
        {
          i = i.Parent;
        }
        if (i != null && i.Parent != null && i.Visualization.Layout != null && i.HasChildren)
        {
          return i.DisplayName.Replace("-", " ");
        }

        return null;
      }
      catch { return null; }
    }
  }
}