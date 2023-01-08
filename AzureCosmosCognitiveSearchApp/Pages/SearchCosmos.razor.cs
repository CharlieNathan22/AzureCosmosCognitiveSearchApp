using AzureCosmosCognitiveSearchApp.CosmosAPI;
using AzureCosmosCognitiveSearchApp.Models;
using Microsoft.AspNetCore.Components;

namespace AzureCosmosCognitiveSearchApp.Pages
{
    public partial class SearchCosmos
    {
        private bool hasSearched { get; set; }

        private Customer SearchInput { get; set; } = new Customer();

        //public IEnumerable<Customer> users { get; set; } = new List<Customer>();

        protected override async Task OnInitializedAsync()
        {
            hasSearched= false;
            await base.OnInitializedAsync();
        }

        private async Task NameSearch()
        {
            if(string.IsNullOrEmpty(SearchInput.Name))
            {
                //users = await CosmosDBService.CosmosGetUsers(new Dictionary<string, string>() { { "", "" } });
                StateHasChanged();
                hasSearched = true;
            } else
            {
                //sers = await CosmosDBService.CosmosGetUsers(new Dictionary<string, string>() { { "id", SearchInput.Id } });
                StateHasChanged();
                hasSearched = true;
            }
        }
    }
}
