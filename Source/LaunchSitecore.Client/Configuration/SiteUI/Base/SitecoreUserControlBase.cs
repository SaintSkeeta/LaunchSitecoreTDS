using System.Web.UI.WebControls;
using LaunchSitecore.Configuration.AuthoringExperience.PageEditor;
using Sitecore.Data;
using Sitecore.Data.Items;
using System;
using Sitecore.ContentSearch;
using System.Linq;
using Sitecore.ContentSearch.Utilities;
using Sitecore.Buckets.Util;
using System.Collections.Generic;
using LaunchSitecore.Configuration.SiteUI.Search.Helper;
using LaunchSitecore.Configuration.SiteUI.Search.Models;

namespace LaunchSitecore.Configuration.SiteUI.Base
{
  public class SitecoreUserControlBase : System.Web.UI.UserControl
  {
    /// <summary>
    /// Automatically resets the Context item to the specified datasource if not null.
    /// This prevents you from needing to do this on every control.
    /// </summary>
    /// <param name="writer"></param>
    protected override void Render(System.Web.UI.HtmlTextWriter writer)
    {
      try
      {
        if (!IsDataSourceItemNull)
        {
          var context = DataSourceItem;
          using (new ContextItemSwitcher(context))
          {
            base.Render(writer);
            return;
          }
        }
        base.Render(writer);
      }
      catch (Exception)
      {
        base.Render(writer);
      }
    }

    /// <summary>
    /// Returns the DataSource Item specified by the user when Sublayout is added to the page.  If not specified, returns the current item
    /// </summary>
    /// <code>
    /// uses GetItem(ID) instead of GetItem(String) method to take advantage of Item cache
    /// </code>
    protected Item DataSourceItemOrCurrentItem
    {
      get
      {
        try
        {
          return string.IsNullOrEmpty(Attributes["sc_datasource"])
                   ? Sitecore.Context.Item
                   : Sitecore.Context.Database.GetItem(new ID(Attributes["sc_datasource"]));
        }
        catch (Exception)
        {
          return Sitecore.Context.Item;
        }
      }
    }

    /// <summary>
    /// Returns the DataSource Item specified by the user when Sublayout is added to the page.  If not specified, returns null
    /// </summary>
    /// <code>
    /// uses GetItem(ID) instead of GetItem(String) method to take advantage of Item cache
    /// </code>
    protected Item DataSourceItem
    {
      get
      {
        try
        {
          return string.IsNullOrEmpty(Attributes["sc_datasource"])
                   ? null
                   : Sitecore.Context.Database.GetItem(new ID(Attributes["sc_datasource"]));
        }
        catch (Exception)
        {
          return null;
        }
      }
    }

    /// <summary>
    /// Checks if sc_datasource attribute is empty or null
    /// </summary>
    protected bool IsDataSourceItemNull
    {
      get
      {
        try
        {
          return string.IsNullOrEmpty(Attributes["sc_datasource"]) ||
                 Sitecore.Context.Database.GetItem(new ID(Attributes["sc_datasource"])) == null;
        }
        catch (Exception)
        {
          return true;
        }
      }
    }

    /// <summary>
    /// Check if datasource is a query...Not Implemented
    /// This seems like a method that would be useful, but we use query items instead of queries in the datasource.
    /// The extra level of abstraction makes personalization easier and gives us query reuse.
    /// Since we never needed this method, we have not implemented it yet. 
    /// </summary>
    protected bool IsDataSourceQuery {
      get
      {
        try
        {
          throw new NotImplementedException("The IsDataSourceQuery is not implemented in the SitecoreUserControlBase class.");
          //return false;
        }
        catch (Exception)
        {
          return false;
        }
      }
    }
    
    /// <summary>
    /// 
    /// </summary>
    protected int DataSourceChildCount
    {
      get
      {
        try
        {
          return string.IsNullOrEmpty(Attributes["sc_datasource"])
                   ? 0
                   : Sitecore.Context.Database.GetItem(new ID(Attributes["sc_datasource"])).Children.Count;
        }
        catch (Exception)
        {
          return 0;
        }
      }
    }
    
    /// <summary>
    /// If the datasource is based on our query template or is a query, we can execute the search here and return a list of items.
    /// </summary>
    protected List<Item> DataSourceItems
    {
      get
      {
        // see if the datasource is a query item        
        if (!IsDataSourceItemNull && DataSourceItem.TemplateName.ToLower() == "query")
        {
          int items;
          // try to parse the items, but if it fails just use 100;
          try { items = Convert.ToInt32(DataSourceItem["items"]); }
          catch { items = 100; }

          if (DataSourceItem.Fields["Query"] != null)
          {
            using (IProviderSearchContext context = ContentSearchManager.CreateSearchContext((SitecoreIndexableItem)(Sitecore.Context.Item)))
            {
              string languageCode = Sitecore.Context.Language.Name.ToLower();
              IQueryable<Item> queryable = (from toItem in LinqHelper.CreateQuery<SitecoreItem>(context, SearchStringModel.ParseDatasourceString(DataSourceItem.Fields["Query"].Value))
                                            where toItem.Language == languageCode                                           
                                            select toItem.GetItem());

              // the master index will have each version so we need to remove the duplicates.
              if (Sitecore.Context.Item.Database.Name.ToLower() == "master")
                return queryable.ToList<Item>().Distinct(new ItemIDComparer()).Take<Item>(items).ToList<Item>();
              else
                return queryable.Take<Item>(items).ToList<Item>();
            } 
          }
        }        
        
        // if the datasource was not a query item try to process the datasource as a query
        try
        {
          //Open search context based off the current item
          using (IProviderSearchContext context = ContentSearchManager.CreateSearchContext((SitecoreIndexableItem)(Sitecore.Context.Item)))
          {
            string languageCode = Sitecore.Context.Language.CultureInfo.TwoLetterISOLanguageName.ToString();
            IQueryable<Item> queryable = (from toItem in LinqHelper.CreateQuery<SitecoreItem>(context, SearchStringModel.ParseDatasourceString(Attributes["sc_datasource"]))
                                          where toItem.Language == languageCode 
                                          select toItem.GetItem());

            // the master index will have each version so we need to remove the duplicates.
            if (Sitecore.Context.Item.Database.Name.ToLower() == "master")
              return queryable.ToList<Item>().Distinct(new ItemIDComparer()).ToList<Item>();
            else
              return queryable.ToList<Item>();
          }
        }
        catch (Exception)
        {
          return null;
        }
      }
    }

    /// <summary>
    /// If the datasource is based on our query template or is a query, we can execute the search here and return a list of items.
    /// </summary>
    protected List<Item> GetDataSourceItemsFromQuery(string query)
    {
      try
      {
        //Open search context based off the current item
        using (IProviderSearchContext context = ContentSearchManager.CreateSearchContext((SitecoreIndexableItem)(Sitecore.Context.Item)))
        {
          string languageCode = Sitecore.Context.Language.CultureInfo.TwoLetterISOLanguageName.ToString();
          IQueryable<Item> queryable = (from toItem in LinqHelper.CreateQuery<SitecoreItem>(context, SearchStringModel.ParseDatasourceString(query))
                                        where toItem.Language == languageCode
                                        select toItem.GetItem());

          // the master index will have each version so we need to remove the duplicates.
          if (Sitecore.Context.Item.Database.Name.ToLower() == "master")
            return queryable.ToList<Item>().Distinct(new ItemIDComparer()).ToList<Item>();
          else
            return queryable.ToList<Item>();
        }
      }
      catch 
      {
        return new List<Item>();
      }                     
    }
    
    /// <summary>
    /// Frequently referenced property
    /// </summary>
    protected bool IsPageEditorEditing
    {
      get { return Sitecore.Context.PageMode.IsPageEditorEditing; }
    }

    /// <summary>
    /// For launch sitecore we are using an alerts system in page editor to notify the user of potential problems.
    /// </summary>
    protected void WriteAlert(string key)
    {
      try
      {
        var literal = new Literal
        {
          Text = new AlertDictionary()[key]
        };
        Controls.Add(literal);
      }
      catch (Exception exception)
      {
        Sitecore.Diagnostics.Log.Error("Cannot apply alert to control", exception);
      }
    }
    
    /// <summary>
    /// Wraps the standard sitecore dictionary call.  In order to have all site labels and standard text managed within the CMS, we use the dictionary.
    /// These items simply hold the value for each label.    
    /// </summary>
    /// <param name="key">The dictionary key you are requesting.</param>
    /// <returns>The phrase value for the requested key.</returns>
    protected string GetDictionaryText(string key)
    {
      return Sitecore.Globalization.Translate.Text(key);
    }
  }
}