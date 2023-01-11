using Azure.Search.Documents.Indexes;

namespace AzureCosmosCognitiveSearchApp.Models
{
    public class Vendor
    {
        [SimpleField(IsFilterable = true, IsFacetable = true, IsSortable = true)]
        public string number { get; set; } = string.Empty;

        [SearchableField(IsFilterable = true, IsFacetable = true)]
        public string name { get; set; } = string.Empty;

        [SimpleField(IsFilterable = true, IsFacetable = true)]
        public bool newVendor { get; set; }
    }
}
