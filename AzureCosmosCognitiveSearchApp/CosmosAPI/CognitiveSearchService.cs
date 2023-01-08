using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Models;
using AzureCosmosCognitiveSearchApp.Models;
using Microsoft.Azure.Cosmos.Linq;
                     
namespace AzureCosmosCognitiveSearchApp.CosmosAPI
{
    public class CognitiveSearchService : ICognitiveSearchService
    {
        private readonly SearchClient SearchClient;

        public CognitiveSearchService(IConfiguration config)
        {
            string SearchIndexName = config.GetConnectionString("SearchIndexName");
            SearchClient = CreateSearchClientForQueries(config, SearchIndexName);
        }

        private static SearchClient CreateSearchClientForQueries(IConfiguration myConfig, string searchIndexName)
        {
            string searchServiceEndPoint = myConfig.GetConnectionString("SearchEdnpointUri");
            string queryApiKey = myConfig.GetConnectionString("SearchRead-OnlyPK");

            SearchClient searchClient = new (new Uri(searchServiceEndPoint), searchIndexName, new AzureKeyCredential(queryApiKey));
            return searchClient;
        }
        private static SearchOptions CreateOptions(SearchData searchData)
        {
            string filters = CreateFilters(searchData);
            SearchOptions options = new SearchOptions() { Filter = filters };
            options.Select.Add(CreateSelect(searchData.ItemTypeFilter));
            options.OrderBy.Add("department desc");
            options.Facets.Add("sourceSystem");
            options.Facets.Add("division");
            options.Facets.Add("department, count:5");
            options.Facets.Add("vendor/name, count:5");
            options.Facets.Add("sellerCurrency, count:5");
            return options;
        }

        public async Task<SearchResults<T>> SearchIndex<T>(SearchData searchData)
        {
            var searchResult = await SearchClient.SearchAsync<T>(searchData.SearchText, CreateOptions(searchData));
            return searchResult.Value;
        }

        private static string CreateFilters(SearchData searchData)
        {
            List<string> filtersList = new()
            {
                $"itemType eq '{searchData.ItemTypeFilter}'"
            };
            if (!string.IsNullOrEmpty(searchData.CreatedByFilter))
            {
                filtersList.Add($"createdBy eq '{searchData.CreatedByFilter}'");

            }
            if (!string.IsNullOrEmpty(searchData.DepartmentFilter))
            {
                filtersList.Add($"department eq '{searchData.DepartmentFilter}'");

            }
            if (!string.IsNullOrEmpty(searchData.DivisionFilter))
            {
                filtersList.Add($"division eq '{searchData.DivisionFilter}'");

            }
            if (!string.IsNullOrEmpty(searchData.CurrencyFilter))
            {
                filtersList.Add($"sellerCurrency eq '{searchData.CurrencyFilter}'");

            }
            if (!string.IsNullOrEmpty(searchData.VendorNameFilter))
            {
                filtersList.Add($"vendor/name eq '{searchData.VendorNameFilter}'");

            }
            return string.Join(" and ", filtersList);
        }

        private static string CreateSelect(string itemType)
        {
            if (itemType.Equals("saleHeader"))
            {
                return "id, itemType, saleNumber, sourceSystem, division, viewingCurrency, sellerCurrency, department, saleName, statusCode, importIndicator, customer/code, customer/name, vendor/number, vendor/name, vendor/newVendor, notes, createdBy, createdDate";
            }
            else if (itemType.Equals("saleAttachment")){
                return "id, itemType, saleNumber, division, fileName, documentType, createdBy, createdDate";
            } 
            else return string.Empty;
        }
    }
}
