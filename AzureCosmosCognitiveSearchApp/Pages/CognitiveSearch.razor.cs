﻿using Azure.Search.Documents.Models;
using AzureCosmosCognitiveSearchApp.Models;
using Microsoft.Azure.Cosmos;
using MudBlazor;
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
        private long? DocumentResultCount { get; set; }
        private SearchData SearchData { get; set; } = new SearchData();
        
        protected override async Task OnInitializedAsync()
        {
            SearchData = new SearchData();
            await base.OnInitializedAsync();
        }

        private async Task Search()
        {
            if(SearchData.ItemTypeFilter.Equals("saleHeader"))
            {
                var results = await CognitiveSearchService.SearchIndex<SaleHeader>(SearchData);
                SaleHeaders = results.GetResults().Select(r => r.Document).ToList();
                DocumentResultCount = SaleHeaders.Count();
                GetFacets(results);
            }
            else
            {
                ClearFilters();
                var results = await CognitiveSearchService.SearchIndex<SaleAttachment>(SearchData);
                SaleAttachements = results.GetResults().Select(r => r.Document).ToList();
                DocumentResultCount = SaleAttachements.Count();
                GetFacets(results);
            }
            StateHasChanged();
        }

        private void GetFacets<T>(SearchResults<T> results)
        {
            DepartmentFacet = results.Facets["department"].Select(x => Tuple.Create(x.Value.ToString(), x.Count)).ToList();
            DivisionFacet = results.Facets["division"].Select(x => Tuple.Create(x.Value.ToString(), x.Count)).ToList();
            CurrencyFacet = results.Facets["sellerCurrency"].Select(x => Tuple.Create(x.Value.ToString(), x.Count)).ToList();
            VendorNameFacet = results.Facets["vendor/name"].Select(x => Tuple.Create(x.Value.ToString(), x.Count)).ToList();
        }

        private void ClearFilters()
        {
            SearchData.DivisionFilter = string.Empty;
            SearchData.CurrencyFilter = string.Empty;
            SearchData.VendorNameFilter = string.Empty;
            SearchData.DepartmentFilter = string.Empty;
        }

        private void ClearFilter(string filter)
        {
            switch (filter)
            {
                case "department":
                    SearchData.DepartmentFilter = string.Empty;
                    break;
                case "division":
                    SearchData.DivisionFilter = string.Empty;
                    break;
                case "currency":
                    SearchData.CurrencyFilter = string.Empty;
                    break;
                case "vendorName":
                    SearchData.VendorNameFilter = string.Empty;
                    break;
            }
        }
    }
}
