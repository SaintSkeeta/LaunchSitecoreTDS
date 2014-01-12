using System;
using Sitecore.Data;
using Sitecore.Configuration;
using Sitecore.Links;
using System.Drawing;

namespace LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Search
{
    public partial class SearchBoxMobile : System.Web.UI.UserControl
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtCriteria.Text != String.Empty)
                openSearchPage();
        }

        protected void txtCriteria_TextChanged(object sender, EventArgs e)
        {
          if (txtCriteria.Text != String.Empty)
            openSearchPage();
        }

        private void openSearchPage()
        {
            Database database = Sitecore.Context.Database;
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