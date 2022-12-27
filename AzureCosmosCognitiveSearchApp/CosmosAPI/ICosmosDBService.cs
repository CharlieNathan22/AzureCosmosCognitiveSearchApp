using AzureCosmosCognitiveSearchApp.Models;

namespace AzureCosmosCognitiveSearchApp.CosmosAPI
{
    public interface ICosmosDBService
    {
        public Task<IEnumerable<Customer>> CosmosGetUsers(Dictionary<string, string> filters);
    }
}
