using Azure.Search.Documents.Models;

namespace AzureCosmosCognitiveSearchApp.Models
{
    public class SearchData
    {
        // The list of results.
        public SearchResults<Customer>? resultList;

        // The text to search for.
        public string searchText { get; set; } = string.Empty;

        // Filter by region Facet
        public string regionFilter { get; set; } = string.Empty;
    }
}