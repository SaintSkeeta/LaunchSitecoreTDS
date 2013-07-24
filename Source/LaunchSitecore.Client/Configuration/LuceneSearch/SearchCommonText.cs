using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace LaunchSitecore.Configuration.LuceneSearch
{
    /// <summary>
    /// Common Text helper class for the search module
    /// </summary>  
    public class SearchCommonText
    {
        private static readonly Database db;

        static SearchCommonText()
        {
            db = Sitecore.Context.Database;
        }

        public static string get(string name)
        {
            Item commonText = db.GetItem("/sitecore/content/configuration/search/" + name);
            return commonText == null ? null : commonText["text"];
        }
    }
}