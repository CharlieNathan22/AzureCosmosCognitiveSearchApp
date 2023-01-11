using Azure.Search.Documents.Indexes;

namespace AzureCosmosCognitiveSearchApp.Models
{
    public class Customer
    {
        [SimpleField(IsFilterable = true, IsFacetable = true, IsSortable = true)]
        public int code { get; set; }

        [SearchableField(IsFilterable = true, IsFacetable = true)]
        public string name { get; set; } = string.Empty;
    }
}
