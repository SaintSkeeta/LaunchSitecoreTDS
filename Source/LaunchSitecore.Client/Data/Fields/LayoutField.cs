namespace LaunchSitecore.Data.Fields
{
    using System;
    using System.Collections;

    using SC = Sitecore;

    public class LayoutField : SC.Data.Fields.LayoutField
    {
        public LayoutField(SC.Data.Fields.Field innerField)
            : base(innerField)
        {
        }

        public LayoutField(SC.Data.Items.Item item)
            : base(item)
        {
        }

        public LayoutField(SC.Data.Fields.Field innerField, string runtimeValue)
            : base(innerField, runtimeValue)
        {
        }

        public override void RemoveLink(SC.Links.ItemLink itemLink)
        {
            SC.Diagnostics.Assert.ArgumentNotNull(itemLink, "itemLink");
            base.RemoveLink(itemLink);
            string xml = this.Value;

            if (String.IsNullOrEmpty(xml))
            {
                return;
            }

            SC.Layouts.LayoutDefinition layoutDetails = SC.Layouts.LayoutDefinition.Parse(xml);
            ArrayList devices = layoutDetails.Devices;

            if (devices == null)
            {
                return;
            }

            foreach (SC.Layouts.DeviceDefinition device in devices)
            {
                if (device == null || device.Renderings == null)
                {
                    continue;
                }

                foreach (SC.Layouts.RenderingDefinition rendering in device.Renderings)
                {
                    if (!String.IsNullOrEmpty(rendering.Datasource)
                      && (rendering.Datasource.Equals(itemLink.TargetPath, StringComparison.InvariantCultureIgnoreCase)
                      || rendering.Datasource.Equals(itemLink.TargetItemID.ToString(), StringComparison.InvariantCultureIgnoreCase)))
                    {
                        rendering.Datasource = String.Empty;
                    }
                }
            }

            this.Value = layoutDetails.ToXml();
        }

        public override void Relink(SC.Links.ItemLink itemLink, SC.Data.Items.Item newLink)
        {
            SC.Diagnostics.Assert.ArgumentNotNull(itemLink, "itemLink");
            SC.Diagnostics.Assert.ArgumentNotNull(newLink, "newLink");
            base.Relink(itemLink, newLink);
            string xml = this.Value;

            if (String.IsNullOrEmpty(xml))
            {
                return;
            }

            SC.Layouts.LayoutDefinition layoutDetails = SC.Layouts.LayoutDefinition.Parse(xml);
            ArrayList devices = layoutDetails.Devices;

            if (devices == null)
            {
                return;
            }

            foreach (SC.Layouts.DeviceDefinition device in devices)
            {
                if (device == null || device.Renderings == null)
                {
                    continue;
                }

                foreach (SC.Layouts.RenderingDefinition rendering in device.Renderings)
                {
                    if (!String.IsNullOrEmpty(rendering.Datasource)
                      && (rendering.Datasource.Equals(itemLink.TargetPath, StringComparison.InvariantCultureIgnoreCase)
                      || rendering.Datasource.Equals(itemLink.TargetItemID.ToString(), StringComparison.InvariantCultureIgnoreCase)))
                    {
                        rendering.Datasource = newLink.ID.ToString();
                    }
                }
            }

            this.Value = layoutDetails.ToXml();
        }

        public override void ValidateLinks(SC.Links.LinksValidationResult result)
        {
            SC.Diagnostics.Assert.ArgumentNotNull(result, "result");
            base.ValidateLinks(result);
            string xml = this.Value;

            if (String.IsNullOrEmpty(xml))
            {
                return;
            }

            ArrayList devices = SC.Layouts.LayoutDefinition.Parse(xml).Devices;

            if (devices == null)
            {
                return;
            }

            foreach (SC.Layouts.DeviceDefinition device in devices)
            {
                foreach (SC.Layouts.RenderingDefinition rendering in device.Renderings)
                {
                    if (String.IsNullOrEmpty(rendering.Datasource)
                      || !(rendering.Datasource.StartsWith("/") || rendering.Datasource.StartsWith("{")))
                    {
                        continue;
                    }

                    SC.Data.Items.Item dataSource = this.InnerField.Database.GetItem(rendering.Datasource);

                    if (dataSource != null)
                    {
                        result.AddValidLink(dataSource, dataSource.Paths.FullPath);
                    }
                    else
                    {
                        result.AddBrokenLink(rendering.Datasource);
                    }
                }
            }
        }
    }
}