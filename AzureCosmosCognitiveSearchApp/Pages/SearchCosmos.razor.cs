using AzureCosmosCognitiveSearchApp.CosmosAPI;
using AzureCosmosCognitiveSearchApp.Models;
using Microsoft.AspNetCore.Components;

namespace AzureCosmosCognitiveSearchApp.Pages
{
    public partial class SearchCosmos
    {
        [Inject]
        CosmosDBService CosmosDBService { get; set; }

        public List<Customer>? users { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }
    }
}
