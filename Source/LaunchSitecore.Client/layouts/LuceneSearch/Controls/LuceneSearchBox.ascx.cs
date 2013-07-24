using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Xml.XPath;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Xml.XPath;
using LaunchSitecore.Configuration;

namespace LaunchSitecore.layouts.LuceneSearch.Controls
{   
    public partial class LuceneSearchBox : System.Web.UI.UserControl
    {
        private Database db = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            db = Sitecore.Context.ContentDatabase;
            if (!IsPostBack)
                txtCriteria.Text = SiteConfiguration.GetDictionaryText("Search");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtCriteria.Text != SiteConfiguration.GetDictionaryText("Search"))
                performSearch();
        }

        protected void txtCriteria_TextChanged(object sender, EventArgs e)
        {
            if (txtCriteria.Text != SiteConfiguration.GetDictionaryText("Search"))
                performSearch();
        }

        private void performSearch()
        {
            Database database = Factory.GetDatabase("master");
            var home = database.GetItem(Sitecore.Context.Site.StartPath);

            if (home != null)
            {
                var results = home.Axes.SelectSingleItem(".//*[@@Name='Search Results']");

                if (results != null)
                {

                    string results_url = LinkManager.GetItemUrl(results) + "?searchStr=" + txtCriteria.Text;
                    Response.Redirect(results_url);
                }
                else
                {
                    txtCriteria.ForeColor = Color.Red;
                    txtCriteria.Text = "Unable to find results item";
                }
            }
            else
            {
                txtCriteria.ForeColor = Color.Red;
                txtCriteria.Text = "Unable to find home!";
            }
        }
    }
}