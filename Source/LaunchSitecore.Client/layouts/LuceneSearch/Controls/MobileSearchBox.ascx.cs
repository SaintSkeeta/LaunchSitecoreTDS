using System;
using Sitecore.Data;
using Sitecore.Configuration;
using Sitecore.Links;
using System.Drawing;

namespace LaunchSitecore.layouts.LuceneSearch.Controls
{
    public partial class MobileSearchBox : System.Web.UI.UserControl
    {
        private Database db = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            db = Sitecore.Context.ContentDatabase;            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtCriteria.Text != String.Empty)
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