using AzureCosmosCognitiveSearchApp.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using System.Configuration;
using System.Text;

namespace AzureCosmosCognitiveSearchApp.CosmosAPI
{
    public class CosmosDBService : ICosmosDBService
    {
        // The Azure Cosmos DB endpoint for running this sample.
        private static readonly string EndpointUri = "https://charliecosmosdb.documents.azure.com:443/";

        // The primary key for the Azure Cosmos account.
        private static readonly string PrimaryKey = "2CZVy6j3xXqNjDaAUGIBbCC6anQynDhBfRZbbfQIM8RqGVuLZAZDEjqJt4YKrhUn1Etval9ZP2mEACDbH0e9PA==";

        // The name of the database and container we will create
        private static readonly string databaseId = "ToDoList";
        private static readonly string containerId = "Items";

        // The Cosmos client instance
        private CosmosClient cosmosClient;

        // The database we will create
        private Database database;

        // The container we will create.
        private Container container;

        public CosmosDBService()
        {
            cosmosClient = new CosmosClient(EndpointUri, PrimaryKey, new CosmosClientOptions() { ApplicationName = "CosmosDBCognitiveSearchDemo" });
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

            if (filters.IsNull() || filters.ContainsKey(""))
            {
                return new QueryDefinition(sqlQueryText);
            }

            sqlQueryText.Concat("WHERE c.@filterKey = @filterValue");
            if (filters.Count == 1)
            {
                return new QueryDefinition(sqlQueryText)
                    .WithParameter("@filterKey", filters.FirstOrDefault().Key)
                    .WithParameter("@filterValue", filters.FirstOrDefault().Value);
            }
            else
            {
                int count = 2;
                foreach (var filter in filters)
                {
                    sqlQueryText.Concat($" AND c.@filterKey{count} = @filterValue{count}");
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
