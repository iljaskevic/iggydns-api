using IggyDNSAPI.Models.v1;
using IggyDNSAPI.Repositories.Helpers;
using IggyDNSAPI.Repositories.Models;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Table;
using System.Threading.Tasks;
using System;
using IggyDNSAPI.Helpers;
using Microsoft.Extensions.Configuration;

namespace IggyDNSAPI.Repositories
{
    public interface IDnsEntryRepository
    {
        Task<DnsEntry> GetFormApiMap(string apiKey);
    }

    public class DnsEntryRepository : BaseRepository, IDnsEntryRepository
    {
        private readonly ILogger<DnsEntryRepository> _logger;
        private readonly IConfiguration _config;
        private readonly string _dnsEntryConString;
        private readonly string _dnsEntryTableName;

        public DnsEntryRepository(ILogger<DnsEntryRepository> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
            _dnsEntryConString = _config.GetConnectionString("IggyDNSStorage");
            _dnsEntryTableName = _config["DnsEntryTableName"];
        }

        public async Task<DnsEntry> GetFormApiMap(string apiKey)
        {
            var start = DateTime.Now;
            _logger.LogInformation("Started retrieval of DnsEntry: " + start.ToString());
            CloudTable apiFormTable = GetDNSEntryTable();
            TableOperation retrieveOperation = TableOperation.Retrieve<DnsEntryTableEntity>(Util.ExtractPrimaryKey(apiKey), apiKey);
            TableResult retrievedResult = await apiFormTable.ExecuteAsync(retrieveOperation);
            var end = DateTime.Now;
            _logger.LogInformation("Finished retrieval of DnsEntry: " + DateTime.Now.ToString() + " - (" + end.Subtract(start).TotalMilliseconds + "ms)");
            return ((DnsEntryTableEntity)retrievedResult.Result).ToDnsEntry();
        }

        private CloudTable GetDNSEntryTable()
        {
            return GetTable("helloworld", _dnsEntryConString);
        }
    }
}
