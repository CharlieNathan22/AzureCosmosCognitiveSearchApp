namespace AzureCosmosCognitiveSearchApp.Models
{
    public class SaleHeader
    {
        public string id { get; set; } = string.Empty;

        public string itemType { get; set; } = "saleHeader";

        public string saleNumber { get; set; } = string.Empty;

        public string sourceSystem { get; set; } = string.Empty;

        public string division { get; set; } = string.Empty;

        public string viewingCurrency { get; set; } = string.Empty;

        public string sellerCurrency { get; set; } = string.Empty;

        public string department { get; set; } = string.Empty;

        public string saleName { get; set; } = string.Empty;

        public int statusCode { get; set; }

        public bool importIndicator { get; set; }

        public Customer customer { get; set; } = new Customer();

        public Vendor vendor { get; set; } = new Vendor();

        public string notes { get; set; } = string.Empty;

        public string createdBy { get; set; } = string.Empty;

        public DateTime createdDate { get; set; }
    }
}
