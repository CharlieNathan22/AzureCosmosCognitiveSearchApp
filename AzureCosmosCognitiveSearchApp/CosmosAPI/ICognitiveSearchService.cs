using AzureCosmosCognitiveSearchApp.Models;

namespace AzureCosmosCognitiveSearchApp.CosmosAPI
{
    public interface ICognitiveSearchService
    {
        public Task<SearchData> RunSimpleSearch(SearchData search);
    }
}
