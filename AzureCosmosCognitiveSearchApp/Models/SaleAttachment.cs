using Azure.Search.Documents.Indexes;

namespace AzureCosmosCognitiveSearchApp.Models
{
    public class SaleAttachment
    {
        [SearchableField(IsFilterable = true)]
        public string id { get; set; } = string.Empty;

        [SimpleField(IsFilterable = true, IsFacetable = true, IsSortable = true)]
        public string itemType { get; set; } = "saleAttachment";

        [SimpleField(IsFilterable = true, IsSortable = true)]
        public string saleNumber { get; set; } = string.Empty;

        [SimpleField(IsFilterable = true, IsFacetable = true)]
        public string division { get; set; } = string.Empty;

        [SearchableField]
        public string fileName { get; set; } = string.Empty;

        [SimpleField(IsFilterable = true, IsFacetable = true, IsSortable = true)]
        public string documentType { get; set; } = string.Empty;

        [SearchableField(IsFilterable = true, IsFacetable = true, IsSortable = true)]
        public string createdBy { get; set; } = string.Empty;

        [SimpleField(IsFilterable = true, IsFacetable = true, IsSortable = true)]
        public DateTime createdDate { get; set; }
    }
}
