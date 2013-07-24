using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LaunchSitecore.Configuration.Presentation
{    
    public class RecursiveRepeaterTemplate : ITemplate
    {
        ListItemType templateType;

        public RecursiveRepeaterTemplate(ListItemType type)
        {
            templateType = type;
        }

        public void InstantiateIn(Control container)
        {
            PlaceHolder ph = new PlaceHolder();

            switch (templateType)
            {
                case ListItemType.Header:
                    ph.Controls.Add(new LiteralControl("<ul>"));
                    break;
                case ListItemType.Footer:
                    ph.Controls.Add(new LiteralControl("</ul>"));
                    break;
            }
            container.Controls.Add(ph);
        }
    }
}