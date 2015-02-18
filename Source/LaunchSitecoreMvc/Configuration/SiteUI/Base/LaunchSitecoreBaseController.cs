using LaunchSitecore.Configuration.SiteUI.Search.Helper;
using LaunchSitecore.Configuration.SiteUI.Search.Models;
using LaunchSitecore.Models;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Utilities;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaunchSitecore.Configuration.SiteUI.Base
{
    public class LaunchSitecoreBaseController : Controller
    {
        public ActionResult ShowPageEditorAlert(PageEditorAlert alert)
        {
          return View(alert);
        }

        /// <summary>
        /// Returns the DataSource Item specified by the user when Sublayout is added to the page.  If not specified, returns the current item
        /// </summary>
        protected Item DataSourceItemOrCurrentItem
        {
          get
          {           
            return RenderingContext.Current.Rendering.Item;            
          }
        }

        /// <summary>
        /// Returns the DataSource Item specified by the user when Sublayout is added to the page.  If not specified, returns null
        /// </summary>
        public Item DataSourceItem
        {
          get
          {
            try
            {
              var str = RenderingContext.Current.Rendering.DataSource;
              return string.IsNullOrEmpty(str) ? null : RenderingContext.Current.Rendering.Item;                  
            }
            catch (Exception)
            {
              return null;
            }
          }
        }

        /// <summary>
        ///
        /// </summary>
        protected bool IsDataSourceItemNull
        {
          get
          {
            try
            {
              return string.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource) || RenderingContext.Current.Rendering.Item == null;
            }
            catch (Exception)
            {
              return true;
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
                  using (IProviderSearchContext context = SiteConfiguration.GetSearchContext(Sitecore.Context.Item))
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
                using (IProviderSearchContext context = SiteConfiguration.GetSearchContext(Sitecore.Context.Item))
              {
                string languageCode = Sitecore.Context.Language.CultureInfo.TwoLetterISOLanguageName.ToString();
                IQueryable<Item> queryable = (from toItem in LinqHelper.CreateQuery<SitecoreItem>(context, SearchStringModel.ParseDatasourceString(RenderingContext.Current.Rendering.DataSource))
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
