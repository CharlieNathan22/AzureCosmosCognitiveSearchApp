namespace AzureCosmosCognitiveSearchApp.Models
{
    public class SaleHeader
    {
        public string Id { get; set; } = string.Empty;

        public string ItemType { get; set; } = "saleHeader";

        public string SaleNumber { get; set; } = string.Empty;

        public string SourceSystem { get; set; } = string.Empty;

        public string Division { get; set; } = string.Empty;

        public string ViewingCurrency { get; set; } = string.Empty;

        public string SellerCurrency { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;

        public string SaleName { get; set; } = string.Empty;

        public int StatusCode { get; set; }

        public bool ImportIndicator { get; set; }

        public Customer Customer { get; set; } = new Customer();

        public Vendor Vendor { get; set; } = new Vendor();

        public string Notes { get; set; } = string.Empty;

        public string CreatedBy { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }
    }
}
