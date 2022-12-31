using Azure.Search.Documents.Models;
using AzureCosmosCognitiveSearchApp.CosmosAPI;
using AzureCosmosCognitiveSearchApp.Models;

namespace AzureCosmosCognitiveSearchApp.Pages
{
    public partial class CognitiveSearch
    {
        private bool hasSearched { get; set; }

        public IEnumerable<Customer> Users { get; set; } = new List<Customer>();

        private List<string?> Regions { get; set; } = new List<string?>();
        private SearchData searchData { get; set; } = new SearchData();

        protected override async Task OnInitializedAsync()
        {
            hasSearched = false;
            await base.OnInitializedAsync();
        }

        private async Task Search()
        {
            List<Customer> customers = new List<Customer>();
            searchData = await CognitiveSearchService.RunSimpleSearch(searchData);
            if (searchData.resultList != null)
            {
                var results = searchData.resultList.GetResults().ToList();
                results.ForEach(result =>
                {
                    customers.Add(result.Document);
                });
                Users = customers;
                Regions = searchData.resultList.Facets["region"].Select(x => x.Value.ToString()).ToList();
                StateHasChanged();
                hasSearched = true;
            }
        }
    }
}
