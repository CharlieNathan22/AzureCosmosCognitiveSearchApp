using Azure.Search.Documents.Models;

namespace AzureCosmosCognitiveSearchApp.Models
{
    public class SearchData
    {
        //public SearchResults<CognitiveSearchModel>? resultList;

        // The text to search for.
        public string SearchText { get; set; } = string.Empty;

        // The department filter selected in radio group
        public string DepartmentFilter { get; set; } = string.Empty;

        public string ItemTypeFilter { get; set; } = string.Empty;

        public string DivisionFilter { get; set; } = string.Empty;

        public string CurrencyFilter { get; set; } = string.Empty;

        public string VendorNameFilter { get; set; } = string.Empty;

        public string CreatedByFilter { get; set; } = string.Empty;

        public DateTime? CreatedDateFilter { get; set; }
    }
}