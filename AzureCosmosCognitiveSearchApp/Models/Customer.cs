using Newtonsoft.Json;

namespace AzureCosmosCognitiveSearchApp.Models
{
    public class Customer
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public double WalletAmount { get; set; }

        public string? Region { get; set; }

        // Vehicle History
        public List<string>? List { get; set; }

        public string? Postcode { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
