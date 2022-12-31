using AzureCosmosCognitiveSearchApp.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Azure.Cosmos;

namespace AzureCosmosCognitiveSearchApp.CosmosAPI
{
    public class CosmosDBService : ICosmosDBService
    {
        // The name of the CosmosDB database and container
        private static readonly string databaseId = "ToDoList";
        private static readonly string containerId = "Items";

        // The Cosmos client instance
        private CosmosClient cosmosClient;

        // The database we will create
        private Database database;

        // The container we will create.
        private Container container;

        //My config service to get keys and endpoints from appsettings.json
        private readonly IConfiguration myConfig;

        public CosmosDBService(IConfiguration config)
        {
            myConfig = config;
            cosmosClient = new CosmosClient(myConfig.GetConnectionString("CosmosEndpointUri"), myConfig.GetConnectionString("CosmosPK"), new CosmosClientOptions() { ApplicationName = "CosmosDBCognitiveSearchDemo" });
            database = cosmosClient.GetDatabase(databaseId);
            container = database.GetContainer(containerId);
        }

        /// <summary>
        /// Run a query (using Azure Cosmos DB SQL syntax) against the container
        /// Including the partition key value of lastName in the WHERE filter results in a more efficient query
        /// </summary>
        public async Task<IEnumerable<Customer>> CosmosGetUsers(Dictionary<string, string> filters)
        {
            QueryDefinition queryDefinition = GenerateSQLQuery(filters);
            Console.WriteLine("Running query: {0}\n", queryDefinition.QueryText);
            var queryResultSetIterator = container.GetItemQueryIterator<Customer>(queryDefinition);

            List<Customer> users = new List<Customer>();

            while (queryResultSetIterator.HasMoreResults)
            {
                FeedResponse<Customer> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach (Customer user in currentResultSet)
                {
                    users.Add(user);
                    Console.WriteLine("\tRead {0}\n", user);
                }
            }

            return users;
        }

        private QueryDefinition GenerateSQLQuery(Dictionary<string, string> filters)
        {
            string sqlQueryText = "SELECT * FROM c ";

            if (filters.ContainsKey(""))
            {
                return new QueryDefinition(sqlQueryText);
            }

            sqlQueryText = string.Concat(sqlQueryText, "WHERE c.Name = @filterValue");
            if (filters.Count == 1)
            {
                return new QueryDefinition(sqlQueryText)
                    .WithParameter("@filterValue", filters.FirstOrDefault().Value);
            } else
            {
                int count = 2;
                foreach (var filter in filters)
                {
                    string newFilter = $" AND c.@filterKey{count} = @filterValue{count}";
                    sqlQueryText = string.Concat(sqlQueryText, newFilter);
                    count++;
                }
                QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);

                count = 2;
                foreach (var filter in filters)
                {
                    queryDefinition
                        .WithParameter($"filterKey{count}", filter.Key)
                        .WithParameter($"filterValue{count}", filter.Value);
                    count++;
                }

                return queryDefinition;
            }
        }
    }
}
