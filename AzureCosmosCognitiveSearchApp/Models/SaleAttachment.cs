namespace AzureCosmosCognitiveSearchApp.Models
{
    public class SaleAttachment
    {
        public string id { get; set; } = string.Empty;

        public string itemType { get; set; } = "saleAttachment";

        public string saleNumber { get; set; } = string.Empty;

        public string division { get; set; } = string.Empty;

        public string fileName { get; set; } = string.Empty;

        public string documentType { get; set; } = string.Empty;

        public string createdBy { get; set; } = string.Empty;

        public DateTime createdDate { get; set; }
    }
}
