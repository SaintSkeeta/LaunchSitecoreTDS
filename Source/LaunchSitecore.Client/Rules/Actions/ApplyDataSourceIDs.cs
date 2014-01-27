namespace LaunchSitecore.Rules.Actions
{
    using System;

    using SC = Sitecore;

    public class ApplyDataSourceIDs<T> :
      SC.Rules.Actions.RuleAction<T>
      where T : SC.Rules.RuleContext
    {
        public override void Apply(T ruleContext)
        {
            SC.Diagnostics.Assert.ArgumentNotNull(ruleContext, "ruleContext");
            SC.Diagnostics.Assert.ArgumentNotNull(ruleContext.Item, "ruleContext.Item");
            SC.Data.Fields.LayoutField layoutDetails = ruleContext.Item.Fields[SC.FieldIDs.LayoutField];
            SC.Diagnostics.Assert.IsNotNull(layoutDetails, "layoutDetails");

            if (String.IsNullOrEmpty(layoutDetails.Value)
              || layoutDetails.InnerField.ContainsStandardValue)
            {
                return;
            }

            SC.Layouts.LayoutDefinition layout = SC.Layouts.LayoutDefinition.Parse(layoutDetails.Value);
            bool modified = false;

            for (int i = 0; i < layout.Devices.Count; i++)
            {
                SC.Layouts.DeviceDefinition device = layout.Devices[i] as SC.Layouts.DeviceDefinition;
                SC.Diagnostics.Assert.IsNotNull(device, "device");

                for (int j = 0; j < device.Renderings.Count; j++)
                {
                    SC.Layouts.RenderingDefinition rendering = device.Renderings[j] as SC.Layouts.RenderingDefinition;
                    SC.Diagnostics.Assert.IsNotNull(rendering, "rendering");

                    if (String.IsNullOrEmpty(rendering.Datasource)
                      || !rendering.Datasource.StartsWith("/"))
                    {
                        continue;
                    }

                    SC.Data.Items.Item dataSource = ruleContext.Item.Database.GetItem(rendering.Datasource);

                    if (dataSource == null)
                    {
                        string msg = this
                          + " : unable to retrieve data source item "
                          + rendering.Datasource
                          + " in "
                          + ruleContext.Item.Paths.FullPath;
                        SC.Diagnostics.Log.Warn(msg, this);
                        continue;
                    }

                    rendering.Datasource = dataSource.ID.ToString();
                    modified = true;
                }
            }

            if (modified)
            {
                using (new SC.Data.Items.EditContext(ruleContext.Item, false, false))
                {
                    layoutDetails.Value = layout.ToXml();
                }
            }
        }
    }
}