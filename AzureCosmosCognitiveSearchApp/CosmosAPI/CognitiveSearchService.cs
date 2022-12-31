using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Models;
using AzureCosmosCognitiveSearchApp.Models;
using System.Drawing.Text;
using System.Linq;

namespace AzureCosmosCognitiveSearchApp.CosmosAPI
{
    public class CognitiveSearchService : ICognitiveSearchService
    {
        private SearchClient searchClient;

        public CognitiveSearchService(IConfiguration config)
        {
            string SearchIndexName = config.GetConnectionString("SearchIndexName");
            searchClient = CreateSearchClientForQueries(config, SearchIndexName);
        }

        private static SearchClient CreateSearchClientForQueries(IConfiguration myConfig, string searchIndexName)
        {
            string searchServiceEndPoint = myConfig.GetConnectionString("SearchEdnpointUri");
            string queryApiKey = myConfig.GetConnectionString("SearchRead-OnlyPK");

            SearchClient searchClient = new SearchClient(new Uri(searchServiceEndPoint), searchIndexName, new AzureKeyCredential(queryApiKey));
            return searchClient;
        }

        public async Task<SearchData> RunSimpleSearch(SearchData search)
        {
            SearchOptions options;

            if (!string.IsNullOrWhiteSpace(search.regionFilter))
            {
                string filter = $"region eq '{search.regionFilter}'";
                options = new SearchOptions() { Filter = filter };
                options.Facets.Add("region,count:10");
            } else
            {
                options = new SearchOptions();
                options.Facets.Add("region,count:10");
            }

            if (string.IsNullOrWhiteSpace(search.searchText))
            {
                search.resultList = await searchClient.SearchAsync<Customer>("*", options);
            }
            else
            {
                search.resultList = await searchClient.SearchAsync<Customer>(search.searchText, options);
            }

            return search;
        }
    }
}
