using Azure.Search.Documents.Models;
using AzureCosmosCognitiveSearchApp.Models;
using Microsoft.Azure.Cosmos;
using System.Data;

namespace AzureCosmosCognitiveSearchApp.Pages
{
    public partial class CognitiveSearch
    {
        public IEnumerable<SaleHeader>? SaleHeaders { get; set; }
        public IEnumerable<SaleAttachment>? SaleAttachements { get; set; }

        //Item1 is the value and Item2 is the count
        private List<Tuple<string?, long?>> DepartmentFacet { get; set; } = new();
        private List<Tuple<string?, long?>> CurrencyFacet { get; set; } = new();
        private List<Tuple<string?, long?>> DivisionFacet { get; set; } = new();
        private List<Tuple<string?, long?>> VendorNameFacet { get; set; } = new();
        private List<Tuple<string?, long?>> CreatedByFacet { get; set; } = new();
        private bool HasSearched { get; set; }
        private bool FiltersVisible { get; set; }
        private string SearchbarTooltipText { get; set; } = "Search by Id, Sale Name, Sale Notes and Username";

        private SearchData SearchData { get; set; } = new SearchData();
        
        protected override async Task OnInitializedAsync()
        {
            HasSearched = false;
            FiltersVisible= false;
            SearchData.ItemTypeFilter = "saleHeader";
            SearchData = new SearchData();
            await base.OnInitializedAsync();
        }

        private async Task Search()
        {
            if(SearchData.ItemTypeFilter.Equals("saleHeader"))
            {
                var results = await CognitiveSearchService.SearchIndex<SaleHeader>(SearchData);
                SaleHeaders = results.GetResults().Select(r => r.Document).ToList();
                GetFacets(results);
            }
            else
            {
                var results = await CognitiveSearchService.SearchIndex<SaleAttachment>(SearchData);
                SaleAttachements = results.GetResults().Select(r => r.Document).ToList();
                GetFacets(results);
            }

            if(SaleHeaders is not null || SaleAttachements is not null)
            {
                HasSearched = true;
                StateHasChanged();
            }
        }

        private void GetFacets<T>(SearchResults<T> results)
        {
            DepartmentFacet = results.Facets["department"].Select(x => Tuple.Create(x.Value.ToString(), x.Count)).ToList();
            DivisionFacet = results.Facets["division"].Select(x => Tuple.Create(x.Value.ToString(), x.Count)).ToList();
            CurrencyFacet = results.Facets["sellerCurrency"].Select(x => Tuple.Create(x.Value.ToString(), x.Count)).ToList();
            VendorNameFacet = results.Facets["vendor/name"].Select(x => Tuple.Create(x.Value.ToString(), x.Count)).ToList();
            CreatedByFacet = results.Facets["createdBy"].Select(x => Tuple.Create(x.Value.ToString(), x.Count)).ToList();
        }

        private void ClearFilters()
        {
            SearchData.CreatedDateFilter = null;
            SearchData.DivisionFilter = string.Empty;
            SearchData.CurrencyFilter = string.Empty;
            SearchData.VendorNameFilter = string.Empty;
            SearchData.CreatedByFilter = string.Empty;
            SearchData.DepartmentFilter = string.Empty;
        }
    }
}
