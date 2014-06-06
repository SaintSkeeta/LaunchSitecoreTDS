using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Pipelines.GetRenderingDatasource;
using Sitecore.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultipleDataSourceLocationsWithQueries.Pipelines.GetRenderingDatasource
{
    public class GetDataSourceLocation
    {
        public void Process(GetRenderingDatasourceArgs args)
        {
            Assert.IsNotNull(args, "args");
            DatasourceLocation = args.RenderingItem["Datasource Location"];
            ContextItemPath = args.ContextItemPath;
            ContentDataBase = args.ContentDatabase;
            DatasourceRoots = args.DatasourceRoots;

            if (QueryInDataSourceLocation())
            {
                ProcessQuerys(args);
            }
        }

        private void ProcessQuerys(GetRenderingDatasourceArgs args)
        {

            ListString possibleQueries = new ListString(DatasourceLocation);
            foreach (string possibleQuery in possibleQueries)
            {
                if (possibleQuery.StartsWith(_query))
                {
                    ProcessQuery(possibleQuery);
                }
            }

        }
        private bool QueryInDataSourceLocation()
        {
            return DatasourceLocation.Contains(_query);
        }

        private void ProcessQuery(string query)
        {

            Item[] datasourceLocations = ResolveDatasourceRootFromQuery(query);
            if (datasourceLocations != null && datasourceLocations.Any())
            {
                foreach (Item dataSourceLocation in datasourceLocations)
                {
                    if (!DatasourceRoots.Exists(x => x.ID.Equals(dataSourceLocation.ID)))
                    {
                        DatasourceRoots.Add(dataSourceLocation);
                    }
                }
            }
        }

        private Item[] ResolveDatasourceRootFromQuery(string query)
        {
            string queryPath = query.Replace(_query, ContextItemPath);
            return ContentDataBase.SelectItems(queryPath);
        }

        private string DatasourceLocation { get; set; }
        private string ContextItemPath { get; set; }
        private Database ContentDataBase { get; set; }
        private List<Item> DatasourceRoots { get; set; }
        private const string _query = "query:.";
    }
}