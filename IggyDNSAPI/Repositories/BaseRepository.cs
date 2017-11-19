using IggyDNSAPI.Models.v1;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Net;

namespace IggyDNSAPI.Repositories
{
    public interface IBaseRepository
    {
        CloudTable GetTable(string tableName, string connString);
    }

    public abstract class BaseRepository : IBaseRepository
    {
        public CloudTable GetTable(string tableName, string connString)
        {
            // Retrieve the storage account from the connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connString);

            ServicePoint tableServicePoint = ServicePointManager.FindServicePoint(storageAccount.TableEndpoint);
            tableServicePoint.UseNagleAlgorithm = false;
            // Create the table client.
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            // Retrieve a reference to the table.
            CloudTable table = tableClient.GetTableReference(tableName);

            return table;
        }
    }
}
