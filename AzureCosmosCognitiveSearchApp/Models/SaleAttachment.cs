namespace AzureCosmosCognitiveSearchApp.Models
{
    public class SaleAttachment
    {
        public string Id { get; set; } = string.Empty;

        public string ItemType { get; set; } = "saleAttachment";

        public string SaleNumber { get; set; } = string.Empty;

        public string Division { get; set; } = string.Empty;

        public string FileName { get; set; } = string.Empty;

        public string DocumentType { get; set; } = string.Empty;

        public string CreatedBy { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }
    }
}
