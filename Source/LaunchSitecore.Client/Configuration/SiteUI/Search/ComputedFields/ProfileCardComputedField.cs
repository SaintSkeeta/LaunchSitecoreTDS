using Sitecore.Analytics.Data;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Data.Managers;
using System;
using System.Collections.Generic;

// This is an example of a computed field in Sitecore.  It is added to the index as the item is saved just like standard fields.
// I wanted an easy way to determine if an Item had a layout specified so I can exclude it from results if needed on the public site.
namespace LaunchSitecore.Configuration.SiteUI.Search.ComputedFields
{
  public class ProfileCardComputedField : IComputedIndexField
  {
    public string FieldName { get; set; }
    public string ReturnType { get; set; }
    public object ComputeFieldValue(IIndexable indexable)
    {
      Item i = ((Item)(indexable as SitecoreIndexableItem));
      if (i["__Tracking"] != String.Empty)
      {
        TrackingField field = new TrackingField(i.Fields["__Tracking"]);
        ContentProfile[] profiles = field.Profiles;

        List<ID> presets = new List<ID>();
        foreach (ContentProfile profile in profiles)
        {
          if (profile.Presets != null)
          {
            foreach (var a in profile.Presets)
            {
              foreach (Item card in profile.GetProfileItem().Axes.GetDescendants())
              {
                if (card.Key == a.Key && card.Template.Key.StartsWith("profile card"))
                  presets.Add(card.ID);
              }
            }
          }
        }
        return presets;
      }
      return string.Empty;
    }
  }
}