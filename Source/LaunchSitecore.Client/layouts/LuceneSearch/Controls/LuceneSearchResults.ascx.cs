using System;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Search;
using Sitecore.Web;
using Sitecore;
using SpellChecker.Net.Search.Spell;
using Lucene.Net.Index;
using LaunchSitecore.Configuration;
using System.Collections.Generic;

namespace LaunchSitecore.layouts.LuceneSearch.Controls
{
    // The search feature uses the system index associated with the master database because this is 
    // a single server solution that should be run in "Live Mode".  If you want the site to support 
    // a separate web database, you must create an associated web database index and specify its name 
    // in the Search Index Item to support search.
    public partial class LuceneSearchResults : System.Web.UI.UserControl
    {
        SearchManager searchMgr;
        string lastUpdatedText;
        SearchResultCollection results;
        List<Item> ResultsList = new List<Item>();

        protected void Page_Load(object sender, EventArgs e)
        {
            //lastUpdatedText = SiteConfiguration.GetDictionaryText("Last Updated");
            //cmdPrev.Text = SiteConfiguration.GetDictionaryText("Previous Button");
            //cmdNext.Text = SiteConfiguration.GetDictionaryText("Next Button");

            //// Decode the search string query string.  Will be empty string if no search string was provided.
            //string searchStr = Server.UrlDecode(WebUtil.GetQueryString("searchStr"));       
                       
            //// If the visitor provided no criteria, don't bother searching
            //if (searchStr == string.Empty)
            //    lblSearchString.Text = SiteConfiguration.GetDictionaryText("Search Criteria") + SiteConfiguration.GetDictionaryText("No Criteria");
            //else
            //{
            //    string indexName = StringUtil.GetString(IndexName, SiteConfiguration.GetSiteSettingsItem()["Search Index"]);
            //    searchMgr = new SearchManager(indexName);

            //    // Remind the visitor what they provided as search criteria
            //    lblSearchString.Text = SiteConfiguration.GetDictionaryText("Search Criteria") + searchStr;

            //    // Perform the actual search
            //    searchMgr.Search(searchStr);
                
            //    // Display the search results
            //    results = searchMgr.SearchResults;

            //    // Now iterate over the number of results 
            //    foreach (var result in results)
            //    {
            //        Item hit = result.GetObject<Item>();
            //        if (hit != null)
            //        {
            //            ResultsList.Add(hit);
            //        }
            //    }

            //    // no results were found so we need to show message and suggestions
            //    if (searchMgr.SearchResults.Count == 0)
            //    {                   
            //        Sitecore.Search.Index index = Sitecore.Search.SearchManager.GetIndex("system");                    
            //        SpellChecker.Net.Search.Spell.SpellChecker spellchecker = new SpellChecker.Net.Search.Spell.SpellChecker(index.Directory);
            //        spellchecker.IndexDictionary(new LuceneDictionary(IndexReader.Open(index.Directory, true), "_content"));
            //        String[] suggestions = spellchecker.SuggestSimilar(searchStr, 5);

            //        if (suggestions.Length > 0)
            //        {
            //            lblSearchString.Text += "<p>";
            //            lblSearchString.Text += SiteConfiguration.GetDictionaryText("Did You Mean");
            //            foreach (string s in suggestions)
            //            {
            //                lblSearchString.Text += String.Format("&nbsp;<a href=\"{0}?searchStr={1}\">{2}</a>&nbsp;", LinkManager.GetItemUrl(Sitecore.Context.Item), s, s);
            //            }
            //            lblSearchString.Text += "</p>";
            //        }
            //        else
            //        {
            //            string noResultsMsg = SiteConfiguration.GetDictionaryText("No Results");
            //            LiteralControl noResults = new LiteralControl(string.Format("<p>{0}</p>", noResultsMsg));
            //            pnResultsPanel.Controls.Add(noResults);
            //        }
            //    }
            //    else
            //    {
            //        if (!Page.IsPostBack)
            //            DisplayResults();
            //    }
            //}
        }

        public string IndexName { get; set; }

        // Display the results
        private void DisplayResults()
        {
            pnResultsPanel.Controls.Clear();

            // Give an appropriate message if we didn't find anything
            if (results.Count > 0)
            {
                PagedDataSource myDS = new PagedDataSource();
                myDS.DataSource = ResultsList;
                myDS.AllowPaging = true;
                myDS.PageSize = System.Convert.ToInt32(SiteConfiguration.GetSiteSettingsItem()["Page Size"]);
                myDS.CurrentPageIndex = CurrentPage;


                lblCurrentPage.Text = String.Format(SiteConfiguration.GetDictionaryText("Page Description"), (CurrentPage + 1), myDS.PageCount);
                cmdPrev.Visible = !myDS.IsFirstPage;
                cmdNext.Visible = !myDS.IsLastPage;

                SearchResults.DataSource = myDS;
                SearchResults.DataBind();
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
    }
}
