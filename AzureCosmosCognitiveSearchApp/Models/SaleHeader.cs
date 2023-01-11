using Azure.Search.Documents.Indexes;

namespace AzureCosmosCognitiveSearchApp.Models
{
    public class SaleHeader
    {
        [SearchableField(IsFilterable = true)]
        public string id { get; set; } = string.Empty;

        [SimpleField(IsFilterable = true, IsFacetable = true, IsSortable = true)]
        public string itemType { get; set; } = "saleHeader";

        [SimpleField(IsFilterable = true, IsSortable = true)]
        public string saleNumber { get; set; } = string.Empty;

        [SimpleField(IsFilterable = true, IsFacetable = true)]
        public string sourceSystem { get; set; } = string.Empty;

        [SimpleField(IsFilterable = true, IsFacetable = true)]
        public string division { get; set; } = string.Empty;

        [SimpleField(IsFilterable = true, IsFacetable = true)]
        public string viewingCurrency { get; set; } = string.Empty;

        [SimpleField(IsFilterable = true, IsFacetable = true)]
        public string sellerCurrency { get; set; } = string.Empty;

        [SimpleField(IsFilterable = true, IsFacetable = true, IsSortable = true)]
        public string department { get; set; } = string.Empty;

        [SearchableField]
        public string saleName { get; set; } = string.Empty;

        [SimpleField(IsFilterable = true, IsFacetable = true, IsSortable = true)]
        public int statusCode { get; set; }

        [SimpleField(IsFilterable = true)]
        public bool importIndicator { get; set; }

        [SearchableField]
        public Customer customer { get; set; } = new Customer();

        [SearchableField]
        public Vendor vendor { get; set; } = new Vendor();

        [SearchableField]
        public string notes { get; set; } = string.Empty;

        [SearchableField(IsFilterable = true, IsFacetable = true, IsSortable = true)]
        public string createdBy { get; set; } = string.Empty;

        [SimpleField(IsFilterable = true, IsFacetable = true, IsSortable = true)]
        public DateTime createdDate { get; set; }
    }
}
