using System;
using System.Web.Mvc;
using System.Web.UI;
using Sitecore.Web.UI.WebControls;

namespace LaunchSitecore.Configuration.Helpers
{
    public static class EditorFrameHelper
    {
        public static EditFrame EditFrameControl;

        private class FrameEditor : IDisposable
        {
            private bool disposed;
            private HtmlHelper html;

            public FrameEditor(HtmlHelper html, string dataSource = null, string buttons = null)
            {
                this.html = html;
                EditorFrameHelper.EditFrameControl = new EditFrame
                {
                    DataSource = dataSource ?? "/sitecore/content/home",
                    Buttons = buttons ?? "/sitecore/content/Applications/WebEdit/Edit Frame Buttons/Default"
                };
                HtmlTextWriter output = new HtmlTextWriter(html.ViewContext.Writer);
                EditorFrameHelper.EditFrameControl.RenderFirstPart(output);
            }

            public void Dispose()
            {
                if (disposed) return;

                disposed = true;

                EditorFrameHelper.EditFrameControl.RenderLastPart(new HtmlTextWriter(html.ViewContext.Writer));
                EditorFrameHelper.EditFrameControl.Dispose();
            }
        }

        public static IDisposable EditFrame(this HtmlHelper html, string dataSource = null, string buttons = null)
        {
            return new FrameEditor(html, dataSource, buttons);
        }
    }
}