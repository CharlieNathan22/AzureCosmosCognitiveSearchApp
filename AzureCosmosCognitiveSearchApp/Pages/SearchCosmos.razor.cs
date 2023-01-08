using AzureCosmosCognitiveSearchApp.CosmosAPI;
using AzureCosmosCognitiveSearchApp.Models;
using Microsoft.AspNetCore.Components;

namespace AzureCosmosCognitiveSearchApp.Pages
{
    public partial class SearchCosmos
    {
        private bool HasSearched { get; set; }

        private Customer SearchInput { get; set; } = new Customer();

        //public IEnumerable<Customer> users { get; set; } = new List<Customer>();

        protected override async Task OnInitializedAsync()
        {
            HasSearched= false;
            await base.OnInitializedAsync();
        }

        private void NameSearch()
        {
            if (string.IsNullOrEmpty(SearchInput.name))
            {
                //users = await CosmosDBService.CosmosGetUsers(new Dictionary<string, string>() { { "", "" } });
                StateHasChanged();
                HasSearched = true;
            }
            else
            {
                //sers = await CosmosDBService.CosmosGetUsers(new Dictionary<string, string>() { { "id", SearchInput.Id } });
                StateHasChanged();
                HasSearched = true;
            }
        }
    }
}
