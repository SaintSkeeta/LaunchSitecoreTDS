using LaunchSitecore.Configuration;
using LaunchSitecore.Configuration.Models;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Search
{
  public partial class SearchResults : System.Web.UI.UserControl
  {
    string lastUpdatedText;    
    List<Item> ResultsList = new List<Item>();
    
    protected void Page_Load(object sender, EventArgs e)
    {
      LoadLabels();      

      // Decode the search string query string.  Will be empty string if no search string was provided.
      string searchStr = Server.UrlDecode(WebUtil.GetQueryString("searchStr"));

      // If the visitor provided no criteria, don't bother searching
      if (searchStr == string.Empty)
        lblSearchString.Text = SiteConfiguration.GetDictionaryText("Search Criteria") + SiteConfiguration.GetDictionaryText("No Criteria");
      else
      {
        // Remind the visitor what they provided as search criteria
        lblSearchString.Text = SiteConfiguration.GetDictionaryText("Search Criteria") + searchStr;

        PerformSearch(searchStr);
        
        if (!Page.IsPostBack)
          DisplayResults();
      }
    }

    public void PerformSearch(string searchStr)
    {
      string indexname = "sitecore_master_index";
      if (Sitecore.Context.PageMode.IsNormal || Sitecore.Context.PageMode.IsDebugging) indexname = "sitecore_web_index";

      using (var context = ContentSearchManager.GetIndex(indexname).CreateSearchContext())
      {
        var query = context.GetQueryable<SitecoreItem>().Where(item => item.HasPresentation && item.Content.Contains(searchStr) && item.Path.StartsWith(Sitecore.Context.Site.StartPath)).GetResults();

        foreach (SearchHit<SitecoreItem> result in query.Hits)
        {
          try
          {
            Item item = result.Document.GetItem();
            if (item != null) { ResultsList.Add(item); }
          }
          catch
          {
            continue;
          }
        }
      }     
    }

    // Display the results
    private void DisplayResults()
    {
      pnResultsPanel.Controls.Clear();

      // Give an appropriate message if we didn't find anything
      if (ResultsList.Count > 0)
      {
        PagedDataSource myDS = new PagedDataSource();
        myDS.DataSource = ResultsList;
        myDS.AllowPaging = true;
        myDS.PageSize = System.Convert.ToInt32(SiteConfiguration.GetSiteSettingsItem()["Page Size"]);
        myDS.CurrentPageIndex = CurrentPage;


        lblCurrentPage.Text = String.Format(SiteConfiguration.GetDictionaryText("Page Description"), (CurrentPage + 1), myDS.PageCount);
        cmdPrev.Visible = !myDS.IsFirstPage;
        cmdNext.Visible = !myDS.IsLastPage;

        rptSearchResults.DataSource = myDS;
        rptSearchResults.DataBind();
      }
    }

    protected void rptSearchResults_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
      {
        Item item = (Item)e.Item.DataItem;
        {
          Image ItemImage = (Image)e.Item.FindControl("ItemImage");
          HyperLink ItemLink = (HyperLink)e.Item.FindControl("ItemLink");
          Literal ShortDescription = (Literal)e.Item.FindControl("ShortDescription");
          Literal LastUpdatedText = (Literal)e.Item.FindControl("LastUpdatedText");
          Literal LastUpdatedDate = (Literal)e.Item.FindControl("LastUpdatedDate");

          if (ItemImage != null && ItemLink != null && ShortDescription != null && LastUpdatedText != null && LastUpdatedDate != null)
          {
            ItemLink.NavigateUrl = LinkManager.GetItemUrl(item);
            if (item["menu title"] != string.Empty) ItemLink.Text = item["menu title"];
            else if (item["title"] != string.Empty) ItemLink.Text = item["title"];
            else ItemLink.Text = item.Name;

            string description;
            if (item["abstract"] != string.Empty) description = item["abstract"];
            else if (item["definition"] != string.Empty) description = item["definition"];
            else if (item["bio"] != string.Empty) description = item["bio"];
            else if (item["body"] != string.Empty) description = item["body"];
            else description = string.Empty;

            description = HtmlRemoval.StripTagsCharArray(description);

            // If the description is too long, shorten it.  If the description is
            // not blank, add a link break after it.
            if (description.Length > 150) description = string.Format("{0}...<br/>", description.Substring(0, 150));
            else if (description.Length > 0) description += "<br/>";

            ShortDescription.Text = description;

            LastUpdatedText.Text = lastUpdatedText;
            DateField lastUpdatedField = item.Fields["__updated"];
            string lastUpdated = (lastUpdatedField != null ? lastUpdatedField.ToString() : "unknown");
            LastUpdatedDate.Text = lastUpdated;

            switch (item.Template.Key)
            {
              case "article":
                ItemImage.ImageUrl = "/images/search/article.png";
                break;
              case "term":
                ItemImage.ImageUrl = "/images/search/term.png";
                break;
              default:
                ItemImage.ImageUrl = "/images/search/page.png";
                break;
            }
          }
        }
      }
    }

    public int CurrentPage
    {
      get
      {
        // look for current page in ViewState
        object o = this.ViewState["_CurrentPage"];
        if (o == null)
        {
          this.ViewState["_CurrentPage"] = 0;
          return 0; // default page index of 0.  
        }
        else
          return (int)o;
      }

      set
      {
        this.ViewState["_CurrentPage"] = value;
      }
    }

    protected void cmdPrev_Click(object sender, EventArgs e)
    {
      // Set viewstate variable to the previous page
      CurrentPage -= 1;

      // Reload control
      DisplayResults();

    }

    protected void cmdNext_Click(object sender, EventArgs e)
    {
      // Set viewstate variable to the next page
      CurrentPage += 1;

      // Reload control
      DisplayResults();
    }

    private void LoadLabels()
    {
      lastUpdatedText = SiteConfiguration.GetDictionaryText("Last Updated");
      cmdPrev.Text = SiteConfiguration.GetDictionaryText("Previous Button");
      cmdNext.Text = SiteConfiguration.GetDictionaryText("Next Button");
    }
  }
}
