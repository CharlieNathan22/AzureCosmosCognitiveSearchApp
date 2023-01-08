using Azure.Search.Documents.Models;
using AzureCosmosCognitiveSearchApp.Models;

namespace AzureCosmosCognitiveSearchApp.CosmosAPI
{
    public interface ICognitiveSearchService
    {
        //public Task<SearchData> RunSimpleSearch(SearchData search);

        public Task<SearchResults<T>> SearchIndex<T>(SearchData searchData);
    }
}
