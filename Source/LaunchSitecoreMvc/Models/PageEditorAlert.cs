using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaunchSitecore.Models
{
  public class PageEditorAlert
  {
    //Methods
    public PageEditorAlert(ID id)
    {
      Assert.IsNotNull(id, "id");
      var item = Sitecore.Context.Database.GetItem(id);
      if (item == null) return;
      Key = Key ?? item[FieldId.Key];
      Alert = Alert ?? item[FieldId.Alert];
      DataSource = DataSource ?? item;
    }

    //Properties
    public string Key { get; protected set; }
    public string Alert { get; protected set; }
    public Item DataSource { get; protected set; }

    //Nested Types
    public static class FieldId
    {
      public static readonly ID Key = ID.Parse("{81B83CAA-E7C3-4333-B54E-9E4670AA5383}");
      public static readonly ID Alert = ID.Parse("{FA03EFA4-692E-456C-89C9-EBEE61BE1112}");
    }

    // Defined Alerts
    public static class Alerts
    {
      public static readonly ID DatasourceIsNull = ID.Parse("{D48D16BD-60D7-413F-BC89-AAF212411AA7}");
      public static readonly ID ItemIsNotTagged = ID.Parse("{B944DC78-6494-4CB6-B650-0DEAF4E6DF9C}");
      public static readonly ID ListIsEmpty = ID.Parse("{5CBEBA13-2A2C-455F-996B-B48D0FD994E2}");
      public static readonly ID NoVersionInCurrentLanguage = ID.Parse("{6A258C65-3949-4E0F-A1C4-17F9304F5177}");
      public static readonly ID VisitDetailsNotAllowedInPageEditor = ID.Parse("{324E820F-DF93-4E65-9E88-40C1D897FC4C}");
    }
  }
}