using Newtonsoft.Json;

namespace AzureCosmosCognitiveSearchApp.Models
{
    public class Customer
    {
        public string id { get; set; } = string.Empty;

        public string name { get; set; } = string.Empty;

        public double walletAmount { get; set; }

        public string region { get; set; } = string.Empty;

        public string postcode { get; set; } = string.Empty;

        public string createdDate { get; set; } = string.Empty;
    }
}
