using AzureCosmosCognitiveSearchApp.CosmosAPI;
using AzureCosmosCognitiveSearchApp.Models;
using Microsoft.AspNetCore.Components;

namespace AzureCosmosCognitiveSearchApp.Pages
{
    public partial class SearchCosmos
    {
        private Customer SearchInput { get; set; } = new Customer();

        public IEnumerable<Customer>? users { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        private async Task NameSearch()
        {
            if(string.IsNullOrEmpty(SearchInput.Name))
            {
                users = await CosmosDBService.CosmosGetUsers(new Dictionary<string, string>());
            }
            users =  await CosmosDBService.CosmosGetUsers(new Dictionary<string, string>() {{ "Name", SearchInput.Name }});
        }
    }
}
